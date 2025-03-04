/*========================================================================================
File: MB3D_Animation_Copilot.Classes.Data_Access_Methods
Description: This class performs functions that interact with a local Sqlite database file.
Original Author: Patrick C. Cook
Copyright: Patrick C. Cook 2025
License: GNU GENERAL PUBLIC LICENSE Version 3
========================================================================================*/

#region Using References Region =========================================

using Dapper;
using MB3D_Animation_Copilot.Models;
using Microsoft.DotNet.DesignTools.Protocol.Values;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Configuration.Provider;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Animation;

#endregion

namespace MB3D_Animation_Copilot.Classes
{
    internal class Data_Access_Methods
    {
        private static string LoadConnectionString()
        {
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

                strConn = strConn.Replace("[AppDataPath]", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
                strConn = strConn.Replace("[AppDataPathSub]", ConfigurationManager.AppSettings["AppDataPathSub"]);
                strConn = strConn.Replace("[dbFileName]", ConfigurationManager.AppSettings["dbFileName"]);

                return strConn;
            }
            catch (Exception ex)
            {
                Program._MainForm.LogException("DAM LoadConnectionString", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ DAM LoadConnectionString. Error was Logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        #region Project Data Access Methods ==========================================================================

        public static int GetProjectRecordCount()
        {
            try
            {

                int KeyframeQuantity = 0;

                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {

                    //Get the coount of project recordws
                    KeyframeQuantity = cnn.ExecuteScalar<int>("SELECT COUNT (*) FROM Animation_Project");
                }

                return KeyframeQuantity;
            }
            catch (Exception ex)
            {
                Program._MainForm.LogException("DAM GetProjectRecordCount", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ DAM GetProjectRecordCount. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public static List<ProjectListModel> LoadProjectsList()
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = cnn.Query<ProjectListModel>("SELECT ID, Project_Name FROM Animation_Project", new DynamicParameters());
                    return output.ToList();
                }
            }
            catch (Exception ex)
            {
                Program._MainForm.LogException("DAM LoadProjectsList", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ DAM LoadProjectsList. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static List<ProjectModel> LoadProjectData(int intProjectID)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = cnn.Query<ProjectModel>("SELECT * FROM Animation_Project WHERE ID=@argProjectID",
                    param: new
                    {
                        @argProjectID = intProjectID
                    });

                    return output.ToList();
                }
            }
            catch (Exception ex)
            {
                Program._MainForm.LogException("DAM LoadProjectData", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ DAM LoadProjectData. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static List<ProjectModel> LoadProjectData_LastSaved()
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = cnn.Query<ProjectModel>("SELECT * FROM Animation_Project WHERE LastSaved_DateTime <> '' ORDER BY LastSaved_DateTime DESC LIMIT 1");
                    return output.ToList();
                }
            }
            catch (Exception ex)
            {
                Program._MainForm.LogException("DAM LoadProjectData_LastSaved", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ DAM LoadProjectData_LastSaved. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static int InsertProjectData(Collection<ProjectModel> colProjectData)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    cnn.Execute("INSERT INTO Animation_Project " +
                        "(Project_Name," +
                        "Project_Notes," +
                        "SlideWalk_StepCount," +
                        "LookingRolling_Angle," +
                        "Frames_Between," +
                        "Key_Delay," +
                        "Total_Frames_Count," +
                        "Far_Plane," +
                        "Animation_Length_30," +
                        "Animation_Length_60," +
                        "M3PIFileLocation," +
                        "M3AFileLocation," +
                        "LastSaved_DateTime)" +
                        "VALUES(" +
                        "@Project_Name," +
                        "@Project_Notes," +
                        "@SlideWalk_StepCount," +
                        "@LookingRolling_Angle," +
                        "@Frames_Between," +
                        "@Key_Delay," +
                        "@Total_Frames_Count," +
                        "@Far_Plane," +
                        "@Animation_Length_30," +
                        "@Animation_Length_60," +
                        "@M3PIFileLocation," +
                        "@M3AFileLocation," +
                        "datetime('now','localtime'))",
                    param: new
                    {
                        colProjectData[0].Project_Name,
                        colProjectData[0].Project_Notes,
                        colProjectData[0].SlideWalk_StepCount,
                        colProjectData[0].LookingRolling_Angle,
                        colProjectData[0].Frames_Between,
                        colProjectData[0].Key_Delay,
                        colProjectData[0].Total_Frames_Count,
                        colProjectData[0].Far_Plane,
                        colProjectData[0].Animation_Length_30,
                        colProjectData[0].Animation_Length_60,
                        colProjectData[0].M3PIFileLocation,
                        colProjectData[0].M3AFileLocation
                    });

                    var NewRecordID = cnn.ExecuteScalar("SELECT MAX(ID) FROM Animation_Project");
                    return Convert.ToInt32(NewRecordID);

                }
            }
            catch (Exception ex)
            {
                Program._MainForm.LogException("DAM InsertProjectData", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ DAM InsertProjectData. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        public static void DeleteAnimationProject(int argParent_ID)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    //Delete the parent record
                    cnn.Execute("DELETE FROM Animation_Project " +
                                "WHERE ID = @argParent_ID",
                    param: new
                    {
                        @argParent_ID = argParent_ID.ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                Program._MainForm.LogException("DAM DeleteAnimationProject", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ DAM DeleteAnimationProject. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void UpdateProjectData(Collection<ProjectModel> colProjectData)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    cnn.Execute("UPDATE Animation_Project " +
                        "SET Project_Name=@Project_Name," +
                        "Project_Notes=@Project_Notes," +
                        "SlideWalk_StepCount=@SlideWalk_StepCount," +
                        "LookingRolling_Angle=@LookingRolling_Angle," +
                        "Frames_Between=@Frames_Between," +
                        "Key_Delay = @Key_Delay," +
                        "Total_Frames_Count=@Total_Frames_Count," +
                        "Far_Plane=@Far_Plane," +
                        "Animation_Length_30 = @AnimationLen30, " +
                        "Animation_Length_60 = @AnimationLen60, " +
                        "M3PIFileLocation = @M3PIFileLocation," +
                        "M3AFileLocation = @M3AFileLocation, " +
                        "LastSaved_DateTime=datetime('now','localtime')" +
                        "WHERE ID = @ID ",
                    param: new
                    {
                        colProjectData[0].Project_Name,
                        colProjectData[0].Project_Notes,
                        colProjectData[0].SlideWalk_StepCount,
                        colProjectData[0].LookingRolling_Angle,
                        colProjectData[0].Frames_Between,
                        colProjectData[0].Key_Delay,
                        colProjectData[0].Total_Frames_Count,
                        colProjectData[0].Far_Plane,
                        @AnimationLen30 = colProjectData[0].Animation_Length_30,
                        @AnimationLen60 = colProjectData[0].Animation_Length_60,
                        colProjectData[0].M3PIFileLocation,
                        colProjectData[0].M3AFileLocation,
                        colProjectData[0].ID
                    });
                }
            }
            catch (Exception ex)
            {
                Program._MainForm.LogException("DAM UpdateProjectData", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ DAM UpdateProjectData. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static DateTime GetProjectLastSavedDateTime(int argParent_ID)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    string strLastSaveDate = cnn.ExecuteScalar<string>("SELECT LastSaved_DateTime FROM Animation_Project WHERE ID = @argParent_ID",
                    param: new
                    {
                        @argParent_ID = argParent_ID.ToString()
                    });

                    return Convert.ToDateTime(strLastSaveDate);

                }
            }
            catch (Exception ex)
            {
                Program._MainForm.LogException("DAM GetProjectLastSavedDateTime", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ DAM GetProjectLastSavedDateTime. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return Convert.ToDateTime(DateTime.Today);
            }
        }

        #endregion

        #region Keyframe Data Access Methods ==========================================================================

        public static int InsertKeyframeData(int intProjectID, KeyframeModel itemKeyframe)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    int intKeyframeID = cnn.ExecuteScalar<int>("INSERT INTO Keyframes " +
                        "(ProjectID_Ref,KeyframeType,KeyframeNum,KeyframeDisplay,FramesBetween,FrameCount,FarPlane,KeyframeNote) " +
                        "VALUES(@intProjectID,@KeyframeType,@KeyframeNum,@KeyframeDisplay,@FramesBetween,@FrameCount,@FarPlane,@KeyframeNote) " +
                        "RETURNING ID",
                    param: new
                    {
                        intProjectID,
                        itemKeyframe.KeyframeType,
                        itemKeyframe.KeyframeNum,
                        itemKeyframe.KeyframeDisplay,
                        itemKeyframe.FramesBetween,
                        itemKeyframe.FrameCount,
                        itemKeyframe.FarPlane,
                        itemKeyframe.KeyframeNote
                    });

                    return intKeyframeID;
                }
            }
            catch (Exception ex)
            {
                Program._MainForm.LogException("DAM InsertKeyframeData", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ DAM InsertKeyframeData. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        public static void InsertKeyframeActionData(int intKeyframeID, KeyframeActionsModel itemKeyframeAction)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    cnn.Execute("INSERT INTO Keyframe_Actions " +
                        "(KeyframesID_Ref," +
                        "ActionName," +
                        "SendKeyChar," +
                        "SendKeyQuantity," +
                        "StepAngleCount) " +
                        "VALUES(" +
                        "@KeframesID_Ref," +
                        "@ActionName," +
                        "@SendKeyChar," +
                        "@SendKeyQuantity," +
                        "@StepAngleCount)",
                    param: new
                    {
                        @KeframesID_Ref = intKeyframeID,
                        itemKeyframeAction.ActionName,
                        itemKeyframeAction.SendKeyChar,
                        itemKeyframeAction.SendKeyQuantity,
                        itemKeyframeAction.StepAngleCount
                    });
                }
            }
            catch (Exception ex)
            {
                Program._MainForm.LogException("DAM InsertKeyframeActionData", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ DAM InsertKeyframeActionData. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static List<KeyframeModel> LoadKeyframes(int intProjectID, bool bolSortAsc)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    string strQueryAsc;
                    if (bolSortAsc)
                    {
                        strQueryAsc = "SELECT ID,KeyframeType,KeyframeNum,KeyframeDisplay,FramesBetween,FrameCount,FarPlane,KeyframeApproved,KeyframeNote" +
                                      " FROM Keyframes" +
                                      " WHERE ProjectID_Ref = @ProjectID" +
                                      " ORDER BY KeyframeNum ASC";
                    }
                    else
                    {
                        strQueryAsc = "SELECT ID,KeyframeType,KeyframeNum,KeyframeDisplay,FramesBetween,FrameCount,FarPlane,KeyframeApproved,KeyframeNote" +
                                      " FROM Keyframes" +
                                      " WHERE ProjectID_Ref = @ProjectID" +
                                      " ORDER BY KeyframeNum DESC";
                    }

                    var output = cnn.Query<KeyframeModel>(strQueryAsc,
                    param: new
                    {
                        @ProjectID = intProjectID
                    });

                    return output.ToList();
                }
            }
            catch (Exception ex)
            {
                Program._MainForm.LogException("DAM LoadKeyframes", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ DAM LoadKeyframes. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static void UpdateKeyframeDisplay(int argKeyframeID, string argKeyframeDisplay)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    cnn.Execute("UPDATE Keyframes" +
                        " SET KeyframeDisplay=@KeyframeDisplay" +
                        " WHERE ID = @KeyframeID",
                    param: new
                    {
                        @KeyframeDisplay = argKeyframeDisplay,
                        @KeyframeID = argKeyframeID
                    });
                }
            }
            catch (Exception ex)
            {
                Program._MainForm.LogException("DAM UpdateKeyframeDisplay", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ DAM UpdateKeyframeDisplay. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void DeleteKeyframeAndKeyframeActions(int argKeyframeID)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    //Delete the Keyframe Actions children records
                    cnn.Execute("DELETE FROM Keyframe_Actions " +
                                "WHERE KeyframesID_Ref = @KeyframeID",
                    param: new
                    {
                        @KeyframeID = argKeyframeID
                    });

                    //Delete the Keyframe record
                    cnn.Execute("DELETE FROM Keyframes " +
                                "WHERE ID = @KeyframeID",
                    param: new
                    {
                        @KeyframeID = argKeyframeID
                    });
                }
            }
            catch (Exception ex)
            {
                Program._MainForm.LogException("DAM DeleteKeyframeAndKeyframeActions", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ DAM DeleteKeyframeAndKeyframeActions. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void DeleteAllKeyframeAndKeyframeActions(int argProjectID)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    cnn.Execute("DELETE FROM Keyframe_Actions WHERE ID IN (" +
                                    "SELECT A.ID FROM Keyframes as K " +
                                    "LEFT JOIN Keyframe_Actions A ON K.ID = A.KeyframesID_Ref " +
                                    "WHERE K.ProjectID_Ref = @ProjectID)",
                    param: new
                    {
                        @ProjectID = argProjectID
                    });

                    cnn.Execute("DELETE FROM Keyframes WHERE ProjectID_Ref = @ProjectID",
                    param: new
                    {
                        @ProjectID = argProjectID
                    });
                }
            }
            catch (Exception ex)
            {
                Program._MainForm.LogException("DAM DeleteAllKeyframeAndKeyframeActions", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ DAM DeleteAllKeyframeAndKeyframeActions. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void DeleteRangeOfKeyframeAndKeyframeActions(int argProjectID, int argStartKeyFrame, int argEndKeyFrame)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    int MaxKeyframeNumber = argEndKeyFrame;

                    //Note: If argEndKeyFrame comes in as -1, let the query determine the highest keyframe number
                    if (MaxKeyframeNumber == -1)
                    {
                        //Get the highest Keyframe number for the project ID argument
                        MaxKeyframeNumber = cnn.ExecuteScalar<int>("SELECT MAX(KeyframeNum)" +
                                                              " FROM Keyframes" +
                                                              " WHERE ProjectID_Ref = @ProjectID",
                        param: new
                        {
                            @ProjectID = argProjectID,
                        });
                    }

                    //Delete Keyframe actions
                    cnn.Execute("DELETE FROM Keyframe_Actions WHERE ID IN (" +
                                    "SELECT A.ID FROM Keyframes as K " +
                                    "LEFT JOIN Keyframe_Actions A ON K.ID = A.KeyframesID_Ref " +
                                    "WHERE K.ProjectID_Ref = @ProjectID " +
                                    "AND K.KeyframeNum BETWEEN @StartKeyFrame AND @EndKeyFrame)",
                    param: new
                    {
                        @ProjectID = argProjectID,
                        @StartKeyFrame = argStartKeyFrame,
                        @EndKeyFrame = MaxKeyframeNumber
                    });

                    //Delete Keyframes
                    cnn.Execute("DELETE FROM Keyframes" +
                                " WHERE ProjectID_Ref = @ProjectID" +
                                " AND KeyframeNum BETWEEN @StartKeyFrame AND @EndKeyFrame",
                    param: new
                    {
                        @ProjectID = argProjectID,
                        @StartKeyFrame = argStartKeyFrame,
                        @EndKeyFrame = MaxKeyframeNumber
                    });
                }
            }
            catch (Exception ex)
            {
                Program._MainForm.LogException("DAM DeleteRangeOfKeyframeAndKeyframeActions", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ DAM DeleteRangeOfKeyframeAndKeyframeActions. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void ApproveRangeOfKeyframe(bool bolApprove, int argProjectID, int argStartKeyFrame, int argEndKeyFrame)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                try
                {
                    //Update Keyframes
                    cnn.Execute("UPDATE Keyframes" +
                                " SET KeyframeApproved = @ApproveState" +
                                " WHERE ProjectID_Ref = @ProjectID" +
                                " AND KeyframeNum BETWEEN @StartKeyFrame AND @EndKeyFrame",
                    param: new
                    {
                        @ProjectID = argProjectID,
                        @ApproveState = bolApprove, //Compiler will convert from boolean to integer
                        @StartKeyFrame = argStartKeyFrame,
                        @EndKeyFrame = argEndKeyFrame
                    });

                }
                catch (Exception ex)
                {
                    Program._MainForm.LogException("DAM ApproveRangeOfKeyframe", ex); //Log this error
                    MessageBoxAdv.Show(ex.Message, "Error @ DAM ApproveRangeOfKeyframe. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static void ApproveByKeyframeID(bool bolApprove, int argProjectID, int argKeyFrameID)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                try
                {
                    //Update Keyframes
                    cnn.Execute("UPDATE Keyframes" +
                                " SET KeyframeApproved = @ApproveState" +
                                " WHERE ProjectID_Ref = @ProjectID" +
                                " AND ID == @KeyFrameID",
                    param: new
                    {
                        @ProjectID = argProjectID,
                        @ApproveState = bolApprove, //Compiler will convert from boolean to integer
                        @KeyFrameID = argKeyFrameID
                    });

                }
                catch (Exception ex)
                {
                    Program._MainForm.LogException("DAM ApproveByKeyframeID", ex); //Log this error
                    MessageBoxAdv.Show(ex.Message, "Error @ DAM ApproveByKeyframeID. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static void UpdateNoteByKeyframeID(string argKeyframeNote, int argProjectID, int argKeyFrameID)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                try
                {
                    //Update Keyframes
                    cnn.Execute("UPDATE Keyframes" +
                                " SET KeyframeNote = @KeyframeNote" +
                                " WHERE ProjectID_Ref = @ProjectID" +
                                " AND ID == @KeyFrameID",
                    param: new
                    {
                        @ProjectID = argProjectID,
                        @KeyframeNote = argKeyframeNote,
                        @KeyFrameID = argKeyFrameID
                    });

                }
                catch (Exception ex)
                {
                    Program._MainForm.LogException("DAM UpdateNoteByKeyframeID", ex); //Log this error
                    MessageBoxAdv.Show(ex.Message, "Error @ DAM UpdateNoteByKeyframeID. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static void UpdateFarPlaneRangeOfKeyframe(int argFarPlane, int argProjectID, int argStartKeyFrame, int argEndKeyFrame)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                try
                {
                    //Update Keyframes
                    cnn.Execute("UPDATE Keyframes" +
                                " SET FarPlane = @FarPlane" +
                                " WHERE ProjectID_Ref = @ProjectID" +
                                " AND KeyframeNum BETWEEN @StartKeyFrame AND @EndKeyFrame",
                    param: new
                    {
                        @ProjectID = argProjectID,
                        @FarPlane = argFarPlane,
                        @StartKeyFrame = argStartKeyFrame,
                        @EndKeyFrame = argEndKeyFrame
                    });

                }
                catch (Exception ex)
                {
                    Program._MainForm.LogException("DAM UpdateFarPlaneRangeOfKeyframe", ex); //Log this error
                    MessageBoxAdv.Show(ex.Message, "Error @ DAM UpdateFarPlaneRangeOfKeyframe. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static void UpdateFramesBetweenRangeOfKeyframe(int argFramesBetween, int argProjectID, int argStartKeyFrame, int argEndKeyFrame)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                try
                {
                    //Update Keyframes
                    cnn.Execute("UPDATE Keyframes" +
                                " SET FramesBetween = @FramesBetween" +
                                " WHERE ProjectID_Ref = @ProjectID" +
                                " AND KeyframeNum BETWEEN @StartKeyFrame AND @EndKeyFrame",
                    param: new
                    {
                        @ProjectID = argProjectID,
                        @FramesBetween = argFramesBetween,
                        @StartKeyFrame = argStartKeyFrame,
                        @EndKeyFrame = argEndKeyFrame
                    });

                }
                catch (Exception ex)
                {
                    Program._MainForm.LogException("DAM UpdateFramesBetweenRangeOfKeyframe", ex); //Log this error
                    MessageBoxAdv.Show(ex.Message, "Error @ DAM UpdateFramesBetweenRangeOfKeyframe. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static void RecalculateFrameCountAllRecords(int argProjectID)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {

                    //Query for a list of all keyframes for the project ID
                    var lstKeyframes = cnn.Query<KeyframeModel>("SELECT ID,FramesBetween,FrameCount" +
                                      " FROM Keyframes" +
                                      " WHERE ProjectID_Ref = @ProjectID" +
                                      " ORDER BY KeyframeNum ASC",
                    param: new
                    {
                        @ProjectID = argProjectID
                    });

                    //Loop the above list to update each keframe of the project ID
                    int intRunningFrameCount = 0;
                    foreach (KeyframeModel kf in lstKeyframes)
                    {
                        //Note: kf.FramesBetween will never be NULL in the database
                        intRunningFrameCount = intRunningFrameCount + kf.FramesBetween;

                        cnn.Execute("UPDATE Keyframes" +
                        " SET FrameCount=@RunningFrameCount" +
                        " WHERE ID=@KeyframeID AND ProjectID_Ref = @ProjectID",
                        param: new
                        {
                            @ProjectID = argProjectID,
                            @KeyframeID = kf.ID,
                            @RunningFrameCount = intRunningFrameCount
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Program._MainForm.LogException("DAM RecalculateFrameCountAllRecords", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ DAM RecalculateFrameCountAllRecords. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static double GetProjectTotalSeconds(int argProjectID)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {

                    //Query for a list of all keyframes for the project ID
                    var lstKeyframes = cnn.Query<KeyframeModel>("SELECT ID,FramesBetween,FrameCount" +
                                      " FROM Keyframes" +
                                      " WHERE ProjectID_Ref = @ProjectID" +
                                      " ORDER BY KeyframeNum ASC",
                    param: new
                    {
                        @ProjectID = argProjectID
                    });

                    //Loop the above list to calculate the animation time of the project per project ID
                    int intRunningFrameCount = 0;
                    foreach (KeyframeModel kf in lstKeyframes)
                    {
                        //Note: kf.FramesBetween will never be NULL in the database
                        intRunningFrameCount = intRunningFrameCount + kf.FramesBetween;
                    }

                    return intRunningFrameCount / 30; //Return the number of project anaiamtion seconds based on 30fps

                }
            }
            catch (Exception ex)
            {
                Program._MainForm.LogException("DAM GetProjectTotalSeconds", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ DAM GetProjectTotalSeconds. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public static void RecalculateKeyframeNumberingAllRecords(int argProjectID)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    //Query for a list of all keyframes for the project ID
                    //This list is based on the current keyframe number in ascending order
                    var lstKeyframes = cnn.Query<KeyframeModel>("SELECT ID" +
                                      " FROM Keyframes" +
                                      " WHERE ProjectID_Ref = @ProjectID" +
                                      " ORDER BY KeyframeNum ASC",
                    param: new
                    {
                        @ProjectID = argProjectID
                    });

                    //Create a variable with an initial value of the lowest keyframe number value (one)
                    int intRunningKeyframeNumber = 1;

                    //Loop the above list to update each keyframe of the project ID to update the Keyframe number
                    foreach (KeyframeModel kf in lstKeyframes)
                    {
                        cnn.Execute("UPDATE Keyframes" +
                        " SET KeyframeNum=@RunningKeyframeNumber" +
                        " WHERE ID=@KeyframeID AND ProjectID_Ref = @ProjectID",
                        param: new
                        {
                            @ProjectID = argProjectID,
                            @KeyframeID = kf.ID,
                            @RunningKeyframeNumber = intRunningKeyframeNumber
                        });

                        intRunningKeyframeNumber += 1;
                    }
                }
            }
            catch (Exception ex)
            {
                Program._MainForm.LogException("DAM RecalculateKeyframeNumberingAllRecords", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ DAM RecalculateKeyframeNumberingAllRecords. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static int GetKeyframeMoveActionsQuantity(int argProjectID, int argKeyframeID)
        {
            try
            {
                int MoveActionsQuantity = 0;

                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {

                    //Get the count of Move Actions for the keyframe ID argument
                    MoveActionsQuantity = cnn.ExecuteScalar<int>("SELECT COUNT(A.ActionName)" +
                                                                 " FROM Keyframes as K LEFT JOIN Keyframe_Actions A ON K.ID = A.KeyframesID_Ref" +
                                                                 " WHERE K.ProjectID_Ref=@ProjectID AND K.ID = @KeyframeID",
                    param: new
                    {
                        @ProjectID = argProjectID,
                        @KeyframeID = argKeyframeID,
                    });
                }

                return MoveActionsQuantity;

            }
            catch (Exception ex)
            {
                Program._MainForm.LogException("DAM GetKeyframeMoveActionsQuantity", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ DAM GetKeyframeMoveActionsQuantity. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public static List<KeyframeActionsModel> LoadKeyframeActionsList(int intKeyframeID)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = cnn.Query<KeyframeActionsModel>("SELECT A.ID, A.ActionName, A.SendKeyChar, A.SendKeyQuantity, A.StepAngleCount" +
                                                                 " FROM Keyframe_Actions A" +
                                                                 " WHERE A.KeyframesID_Ref = @KeyframeID AND A.SendKeyChar <> @InsertCmd" +
                                                                 " ORDER BY A.ID",
                    param: new
                    {
                        @KeyframeID = intKeyframeID,
                        @InsertCmd = MainForm.cNMKk
                    });
                    return output.ToList();
                }
            }
            catch (Exception ex)
            {
                Program._MainForm.LogException("DAM LoadKeyframeActionsList", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ DAM LoadKeyframeActionsList. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;

            }
        }

        public static List<KeyframeActionsModel> LoadKeyframeActionsList_ForKeyframeReplicate(int intProjectID, int idxKeyframeNumber)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = cnn.Query<KeyframeActionsModel>("SELECT A.ID, A.ActionName,A.SendKeyChar,A.SendKeyQuantity,A.StepAngleCount" +
                                                                 " FROM Keyframes as K LEFT JOIN Keyframe_Actions A ON K.ID = A.KeyframesID_Ref" +
                                                                 " WHERE K.ProjectID_Ref=@ProjectID AND K.KeyframeNum = @KeyframeNum" +
                                                                 " ORDER BY A.ID",
                    param: new
                    {
                        @ProjectID = intProjectID,
                        @KeyframeNum = idxKeyframeNumber
                    });
                    return output.ToList();
                }
            }
            catch (Exception ex)
            {
                Program._MainForm.LogException("DAM LoadKeyframeActionsList_ForKeyframeReplicate", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ DAM LoadKeyframeActionsList_ForKeyframeReplicate. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static List<KeyframeActionsModel> LoadLastKeyframeActionsList_ForKeyframeRepeat(int intProjectID)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {

                    int intMaxKeyframeID = GetProjectLastKeyframeID(intProjectID);

                    var output = cnn.Query<KeyframeActionsModel>("SELECT A.ID, A.ActionName,A.SendKeyChar,A.SendKeyQuantity,A.StepAngleCount" +
                                                                 " FROM Keyframes as K LEFT JOIN Keyframe_Actions A ON K.ID = A.KeyframesID_Ref" +
                                                                 " WHERE K.ProjectID_Ref=@ProjectID AND K.ID = @TargetKeyframeID" +
                                                                 " ORDER BY A.ID",
                    param: new
                    {
                        @ProjectID = intProjectID,
                        @TargetKeyframeID = intMaxKeyframeID
                    });
                    return output.ToList();
                }
            }
            catch (Exception ex)
            {
                Program._MainForm.LogException("DAM LoadLastKeyframeActionsList_ForKeyframeRepeat", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ DAM LoadLastKeyframeActionsList_ForKeyframeRepeat. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static List<KeyframeActionsModel> LoadKeyframeAction(int intKeyframeActionID)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = cnn.Query<KeyframeActionsModel>("SELECT A.ID, A.ActionName, A.SendKeyChar, A.SendKeyQuantity, A.StepAngleCount" +
                                                                 " FROM Keyframe_Actions A" +
                                                                 " WHERE A.ID = @KeyframeActionID" +
                                                                 " ORDER BY A.ID",
                    param: new
                    {
                        @KeyframeActionID = intKeyframeActionID
                    });
                    return output.ToList();
                }
            }
            catch (Exception ex)
            {
                Program._MainForm.LogException("DAM LoadKeyframeAction", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ DAM LoadKeyframeAction. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static void UpdateKeyframeAction(int argKeyframeActionID, KeyframeActionsModel itemKeyframeAction)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    cnn.Execute("UPDATE Keyframe_Actions" +
                        " SET ActionName=@ActionName," +
                        " SendKeyChar=@SendKeyChar," +
                        " SendKeyQuantity=@SendKeyQuantity, " +
                        " StepAngleCount=@StepAngleCount " +
                        " WHERE ID = @KeyframeActionID ",
                    param: new
                    {
                        itemKeyframeAction.ActionName,
                        itemKeyframeAction.SendKeyChar,
                        itemKeyframeAction.SendKeyQuantity,
                        itemKeyframeAction.StepAngleCount,
                        @KeyframeActionID = argKeyframeActionID
                    });
                }
            }
            catch (Exception ex)
            {
                Program._MainForm.LogException("DAM UpdateKeyframeAction", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ DAM UpdateKeyframeAction. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void DeleteKeyframeAction(int argKeyframeActionID)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    cnn.Execute("DELETE FROM Keyframe_Actions " +
                                "WHERE ID = @KeyframeActionID",
                    param: new
                    {
                        @KeyframeActionID = argKeyframeActionID
                    });
                }
            }
            catch (Exception ex)
            {
                Program._MainForm.LogException("DAM DeleteKeyframeAction", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ DAM DeleteKeyframeAction. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static int GetProjectLastKeyframeNumber(int argProjectID)
        {
            try
            {
                int intMaxKeyframeNumber = 0;

                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {

                    //Get the highest Keyframe number for the project ID argument
                    intMaxKeyframeNumber = cnn.ExecuteScalar<int>("SELECT MAX(KeyframeNum)" +
                                                                  " FROM Keyframes" +
                                                                  " WHERE ProjectID_Ref = @ProjectID",
                    param: new
                    {
                        @ProjectID = argProjectID,
                    });
                }

                return intMaxKeyframeNumber;

            }
            catch (Exception ex)
            {
                Program._MainForm.LogException("DAM GetProjectLastKeyframeNumber", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ DAM GetProjectLastKeyframeNumber. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public static int GetProjectNextKeyframeNumber(int argProjectID)
        {
            try
            {
                int intMaxKeyframeNumber = 0;

                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {

                    //Get the highest Keyframe number for the project ID argument
                    intMaxKeyframeNumber = cnn.ExecuteScalar<int>("SELECT MAX(KeyframeNum)" +
                                                                  " FROM Keyframes" +
                                                                  " WHERE ProjectID_Ref = @ProjectID",
                    param: new
                    {
                        @ProjectID = argProjectID,
                    });
                }

                if (intMaxKeyframeNumber == 0)
                {
                    //Return 1 value in case there are no Keyframe records and SQL statement above returns NULL
                    return 1;
                }
                else
                {
                    return intMaxKeyframeNumber + 1;
                }
            }
            catch (Exception ex)
            {
                Program._MainForm.LogException("DAM GetProjectNextKeyframeNumber", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ DAM GetProjectNextKeyframeNumber. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 1;
            }
        }

        public static int GetProjectLastKeyframeID(int argProjectID)
        {
            try
            {
                int intMaxKeyframeNumber = 0;
                int intMaxKeyframeID = 0;

                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {

                    //Get the highest Keyframe number for the project ID argument
                    intMaxKeyframeNumber = cnn.ExecuteScalar<int>("SELECT MAX(KeyframeNum)" +
                                                                  " FROM Keyframes" +
                                                                  " WHERE ProjectID_Ref = @ProjectID" +
                                                                  " LIMIT 1",
                    param: new
                    {
                        @ProjectID = argProjectID
                    });

                    //Get the ID of the highest Keyframe number for the project ID argument
                    intMaxKeyframeID = cnn.ExecuteScalar<int>("SELECT ID" +
                                                              " FROM Keyframes" +
                                                              " WHERE ProjectID_Ref = @ProjectID AND KeyframeNum = @KeyframeNumber",
                    param: new
                    {
                        @KeyframeNumber = intMaxKeyframeNumber,
                        @ProjectID = argProjectID
                    });

                }

                return intMaxKeyframeID;

            }
            catch (Exception ex)
            {
                Program._MainForm.LogException("DAM GetProjectLastKeyframeID", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ DAM GetProjectLastKeyframeID. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public static int GetProjectFirstKeyframeNumber(int argProjectID)
        {
            try
            {
                int intMinKeyframeNumber = 0;

                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {

                    //Get the highest Keyframe number for the project ID argument
                    intMinKeyframeNumber = cnn.ExecuteScalar<int>("SELECT MIN(KeyframeNum)" +
                                                               " FROM Keyframes" +
                                                               " WHERE ProjectID_Ref = @ProjectID",
                    param: new
                    {
                        @ProjectID = argProjectID,
                    });
                }

                return intMinKeyframeNumber;

            }
            catch (Exception ex)
            {
                Program._MainForm.LogException("DAM GetProjectFirstKeyframeNumber", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ DAM RecalculateFrameCountAllRecords. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public static int GetProjectKeyframeQuantity(int argProjectID)
        {
            try
            {
                int KeyframeQuantity = 0;

                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {

                    //Get the highest Keyframe number for the project ID argument
                    KeyframeQuantity = cnn.ExecuteScalar<int>("SELECT COUNT(KeyframeNum)" +
                                                               " FROM Keyframes" +
                                                               " WHERE ProjectID_Ref = @ProjectID",
                    param: new
                    {
                        @ProjectID = argProjectID,
                    });
                }

                return KeyframeQuantity;

            }
            catch (Exception ex)
            {
                Program._MainForm.LogException("DAM GetProjectKeyframeQuantity", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ DAM GetProjectKeyframeQuantity. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        #endregion

        #region Move Sequence Data Access Methods ==========================================================================

        public static List<KeyframeModel> LoadKeyframeRangeForMoveSequence(int argProjectID, int argFromKeyframeNum, int argToKeyframeNum)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {

                    var output = cnn.Query< KeyframeModel>("SELECT *" +
                                      " FROM Keyframes" +
                                      " WHERE ProjectID_Ref = @ProjectID" +
                                      " AND KeyframeNum BETWEEN @FromKeyframeNum AND @ToKeyframeNum" +
                                      " ORDER BY KeyframeNum ASC",

                    param: new
                    {
                        @ProjectID = @argProjectID,
                        @FromKeyframeNum = argFromKeyframeNum,
                        @ToKeyframeNum = argToKeyframeNum
                    });

                    return output.ToList();
                }
            }
            catch (Exception ex)
            {
                //var error = ex.Message;
                MessageBoxAdv.Show(ex.Message, "Error @ LoadKeyframes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static void InsertMoveSeqStepsByKeyframeRange(int argProjectID, int argSeqParentID, int argFromKeyframeNum, int argToKeyframeNum)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    cnn.Execute("INSERT INTO Sequence_Steps(SequenceParent_ID, Step_Group, Step_Name, Step_Count, Step_SendKey, Step_SendKeyQty) " +
                                "SELECT @SeqParentID, k.KeyframeNum, a.ActionName, a.StepAngleCount, a.SendKeyChar, a.SendKeyQuantity " +
                                "FROM Keyframes as k LEFT JOIN Keyframe_Actions a ON k.ID = a.KeyframesID_Ref " +
                                "WHERE k.ProjectID_Ref = @ProjectID " +
                                "AND k.KeyframeNum BETWEEN @FromKeyframeNum AND @ToKeyframeNum " +
                                "ORDER BY a.ID",

                    param: new
                    {
                        @ProjectID = argProjectID,
                        @SeqParentID = argSeqParentID,
                        @FromKeyframeNum = argFromKeyframeNum,
                        @ToKeyframeNum = argToKeyframeNum
                    });
                }
            }
            catch (Exception ex)
            {
                //var error = ex.Message;
                MessageBoxAdv.Show(ex.Message, "Error @ InsertMoveSeqStepsByKeyframeRange", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static List<MoveSequenceModel> LoadMoveSeqencesList()
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = cnn.Query<MoveSequenceModel>("SELECT ID, SequenceName, SequenceDesc FROM Sequence_Parent ORDER BY SequenceName", new DynamicParameters());
                    return output.ToList();
                }
            }
            catch (Exception ex)
            {
                //var error = ex.Message;
                MessageBoxAdv.Show(ex.Message, "Error @ LoadMoveSeqencesList", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static List<MoveSequenceModel> LoadMoveSeqenceByParentID(int intSeqParentID)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = cnn.Query<MoveSequenceModel>("SELECT ID, SequenceName, SequenceDesc FROM Sequence_Parent WHERE ID = @SeqParentID",
                    param: new
                    {
                        @SeqParentID = intSeqParentID
                    });
                    return output.ToList();

                }
            }
            catch (Exception ex)
            {
                //var error = ex.Message;
                MessageBoxAdv.Show(ex.Message, "Error @ LoadMoveSeqenceByParentID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static int AddNewSequenceParent(string strNewSeqName, string strNewSeqDesc)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    int SeqParentID = cnn.ExecuteScalar<int>("INSERT INTO Sequence_Parent " +
                                                             "(SequenceName, SequenceDesc) " +
                                                             "VALUES(@strNewSeqName, @strNewSeqDesc) " +
                                                             "RETURNING ID",
                    param: new
                    {
                        strNewSeqName,
                        strNewSeqDesc
                    });

                    return SeqParentID;

                }
            }
            catch (Exception ex)
            {
                //var error = ex.Message;
                MessageBoxAdv.Show(ex.Message, "Error @ AddNewSequenceParent", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public static void DeleteSequence(string argParent_ID)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    //Delete the parent record
                    cnn.Execute("DELETE FROM Sequence_Parent " +
                                "WHERE ID = @argParent_ID",
                    param: new
                    {
                        argParent_ID
                    });

                    //Delete the related Step records
                    cnn.Execute("DELETE FROM Sequence_Steps " +
                                "WHERE SequenceParent_ID = @argParent_ID",
                    param: new
                    {
                        argParent_ID
                    });
                }
            }
            catch (Exception ex)
            {
                //var error = ex.Message;
                MessageBoxAdv.Show(ex.Message, "Error @ DeleteSequence", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Step Sequence Data Access Methods ==========================================================================

        public static List<StepSequenceModel> LoadSequenceStepList(int intParentID)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT Step_ID, Step_Group, Step_Name, Step_Count, Step_SendKey, Step_SendKeyQty ");
                    sb.Append("FROM Sequence_Steps ");
                    sb.Append("INNER JOIN Sequence_Parent ON Sequence_Parent.ID = Sequence_Steps.SequenceParent_ID ");
                    sb.Append("WHERE Sequence_Parent.ID = ");
                    sb.Append(intParentID.ToString());
                    sb.Append(" ORDER BY Step_Group");

                    var output = cnn.Query<StepSequenceModel>(sb.ToString(), new DynamicParameters());
                    return output.ToList();
                }
            }
            catch (Exception ex)
            {
                Program._MainForm.LogException("DAM LoadSequenceStepList", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ DAM LoadSequenceStepList. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static void ManageSeqUpdateStep(int argStepID, int argStepGroup, string argStepName, int argStepCount, string argStepSendKey)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    cnn.Execute("UPDATE Sequence_Steps" +
                        " SET Step_Group=@StepGroup," +
                        " Step_Name=@StepName," +
                        " Step_Count=@StepCount," +
                        " Step_SendKeyQty=@StepSendKeyQty," +
                        " Step_SendKey=@StepSendKey " +
                        " WHERE Step_ID = @StepID ",
                    param: new
                    {
                        @StepGroup = argStepGroup,
                        @StepName = argStepName,
                        @StepCount = argStepCount,
                        @StepSendKeyQty = argStepCount,
                        @StepSendKey = argStepSendKey,
                        @StepID = argStepID
                    });
                }
            }
            catch (Exception ex)
            {
                Program._MainForm.LogException("DAM ManageSeqUpdateStep", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ DAM ManageSeqUpdateStep. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void ManageSeqAddMoveStep(int argSequenceParentID, int argStepGroup, string argMoveStepName, int argMoveStepCount, string argMoveStepSendKey)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    cnn.Execute("INSERT INTO Sequence_Steps " +
                                "(SequenceParent_ID," +
                                " Step_Group," +
                                " Step_Name," +
                                " Step_Count," +
                                " Step_SendKey, " +
                                " Step_SendKeyQty) " +
                                "VALUES(@SequenceParentID," +
                                " @StepGroup," +
                                " @MoveStepName," +
                                " @MoveStepCount," +
                                " @MoveStepSendKey," +
                                " @MoveSendKeyQty)",
                    param: new
                    {
                        @SequenceParentID = argSequenceParentID,
                        @StepGroup = argStepGroup,
                        @MoveStepName = argMoveStepName,
                        @MoveStepCount = argMoveStepCount,
                        @MoveStepSendKey = argMoveStepSendKey,
                        @MoveSendKeyQty = argMoveStepCount,

                    });
                }
            }
            catch (Exception ex)
            {
                Program._MainForm.LogException("DAM ManageSeqAddMoveStep", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ DAM ManageSeqAddMoveStep. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void DeleteStep(int argSequenceParentID, int argMoveStepID)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    cnn.Execute("DELETE FROM Sequence_Steps " +
                                "WHERE Step_ID = @MoveStepID AND SequenceParent_ID = @SequenceParentID",
                    param: new
                    {
                        @SequenceParentID = argSequenceParentID,
                        @MoveStepID = argMoveStepID
                    });
                }
            }
            catch (Exception ex)
            {
                Program._MainForm.LogException("DAM DeleteStep", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ DAM DeleteStep. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Application Admininstration Methods ==========================================================================

        public static bool BackupDatabase(string strDBBackupFileNamePath)
        {
            try
            {
                using (var source = new SQLiteConnection(LoadConnectionString()))
                using (var destination = new SQLiteConnection("Data Source=" + strDBBackupFileNamePath + "; Version=3;"))
                {
                    source.Open();
                    destination.Open();
                    source.BackupDatabase(destination, "main", "main", -1, null, 0);
                }

                return true;
            }
            catch (Exception ex)
            {
                Program._MainForm.LogException("DAM BackupDatabase", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ DAM BackupDatabase. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool RestoreDatabase(string strDBBackupFileNamePath)
        {
            try
            {
                using (var source = new SQLiteConnection("Data Source=" + strDBBackupFileNamePath + "; Version=3;"))
                using (var destination = new SQLiteConnection(LoadConnectionString()))
                {
                    source.Open();
                    destination.Open();
                    source.BackupDatabase(destination, "main", "main", -1, null, 0);
                }

                return true;
            }
            catch (Exception ex)
            {
                Program._MainForm.LogException("DAM RestoreDatabase", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ DAM RestoreDatabase. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool EraseAllDatabaseRecords(bool DeleteMoveSequenceRecords)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    if (DeleteMoveSequenceRecords)
                    {
                        cnn.Execute("DELETE FROM Sequence_Steps");
                        cnn.Execute("DELETE FROM Sequence_Parent");
                    }

                    cnn.Execute("DELETE FROM Keyframe_Actions");
                    cnn.Execute("DELETE FROM Keyframes");

                    cnn.Execute("DELETE FROM Animation_Project");
                }

                return true;

            }
            catch (Exception ex)
            {
                Program._MainForm.LogException("DAM EraseAllDatabaseRecords", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ DAM EraseAllDatabaseRecords. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }

    #endregion

}
