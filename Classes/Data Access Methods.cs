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
using System.Runtime.CompilerServices;
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
        #region Load Connection String Methods ==========================================================================

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

        #endregion

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

        public static int ProjectRecordExistByProjectName(string argProjectName)
        {
            try
            {

                int RecordQuantity = 0;

                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {

                    //Get the coount of project recordws
                    RecordQuantity = cnn.ExecuteScalar<int>("SELECT COUNT (*) FROM Animation_Project WHERE Project_Name = @ProjectName",
                    param: new
                    {
                        @ProjectName = argProjectName
                    });
                }

                return RecordQuantity;
            }
            catch (Exception ex)
            {
                Program._MainForm.LogException("DAM ProjectRecordExistByProjectName", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ DAM ProjectRecordExistByProjectName. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        "SendKeyDelay," +
                        "Total_Frames_Count," +
                        "ProjectFarPlane," +
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
                        "@SendKeyDelay," +
                        "@Total_Frames_Count," +
                        "@ProjectFarPlane," +
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
                        colProjectData[0].SendKeyDelay,
                        colProjectData[0].Total_Frames_Count,
                        colProjectData[0].ProjectFarPlane,
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
                        "SendKeyDelay = @SendKeyDelay," +
                        "Total_Frames_Count=@Total_Frames_Count," +
                        "ProjectFarPlane=@ProjectFarPlane," +
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
                        colProjectData[0].SendKeyDelay,
                        colProjectData[0].Total_Frames_Count,
                        colProjectData[0].ProjectFarPlane,
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
                        "(ProjectID_Ref,KeyframeType,KeyframeNum,KeyframeDisplay,FramesBetween,FrameCount,KeyframeFarPlane,KeyframeNote) " +
                        "VALUES(@intProjectID,@KeyframeType,@KeyframeNum,@KeyframeDisplay,@FramesBetween,@FrameCount,@KeyframeFarPlane,@KeyframeNote) " +
                        "RETURNING ID",
                    param: new
                    {
                        intProjectID,
                        itemKeyframe.KeyframeType,
                        itemKeyframe.KeyframeNum,
                        itemKeyframe.KeyframeDisplay,
                        itemKeyframe.FramesBetween,
                        itemKeyframe.FrameCount,
                        itemKeyframe.KeyframeFarPlane,
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
                        "(KeyframeID_Ref," +
                        "ActionName," +
                        "SendKeyChar," +
                        "SendKeyQuantity," +
                        "StepAngleCount) " +
                        "VALUES(" +
                        "@KeframeID_Ref," +
                        "@ActionName," +
                        "@SendKeyChar," +
                        "@SendKeyQuantity," +
                        "@StepAngleCount)",
                    param: new
                    {
                        @KeframeID_Ref = intKeyframeID,
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
                        strQueryAsc = "SELECT ID,KeyframeType,KeyframeNum,KeyframeDisplay,FramesBetween,FrameCount,KeyframeFarPlane,KeyframeApproved,KeyframeNote" +
                                      " FROM Keyframes" +
                                      " WHERE ProjectID_Ref = @ProjectID" +
                                      " ORDER BY KeyframeNum ASC";
                    }
                    else
                    {
                        strQueryAsc = "SELECT ID,KeyframeType,KeyframeNum,KeyframeDisplay,FramesBetween,FrameCount,KeyframeFarPlane,KeyframeApproved,KeyframeNote" +
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
                                "WHERE KeyframeID_Ref = @KeyframeID",
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

        public static bool DeleteKeyframeActionsOfKeyframe(int argKeyframeID)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    //Delete the Keyframe Actions children records
                    cnn.Execute("DELETE FROM Keyframe_Actions " +
                                "WHERE KeyframeID_Ref = @KeyframeID",
                    param: new
                    {
                        @KeyframeID = argKeyframeID
                    });
                    return true;
                }
            }
            catch (Exception ex)
            {
                Program._MainForm.LogException("DAM DeleteKeyframeActionsOfKeyframe", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ DAM DeleteKeyframeActionsOfKeyframe. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;   
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
                                    "LEFT JOIN Keyframe_Actions A ON K.ID = A.KeyframeID_Ref " +
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
                    int MaxKeyframeNumber = GetHighestKeyframeNumberByProjectID(argProjectID);

                    //Delete Keyframe actions
                    cnn.Execute("DELETE FROM Keyframe_Actions WHERE ID IN (" +
                                    "SELECT A.ID FROM Keyframes as K " +
                                    "LEFT JOIN Keyframe_Actions A ON K.ID = A.KeyframeID_Ref " +
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

        public static int GetHighestKeyframeNumberByProjectID(int argProjectID)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    int MaxKeyframeNumber = 0;

                    //Get the highest Keyframe number for the project ID argument
                    MaxKeyframeNumber = cnn.ExecuteScalar<int>("SELECT MAX(KeyframeNum)" +
                                                            " FROM Keyframes" +
                                                            " WHERE ProjectID_Ref = @ProjectID",
                    param: new
                    {
                        @ProjectID = argProjectID,
                    });

                    return MaxKeyframeNumber;

                }
            }
            catch (Exception ex)
            {
                Program._MainForm.LogException("DAM GetHighestKeyframeNumberByProjectID", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ DAM GetHighestKeyframeNumberByProjectID. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
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

        public static void UpdateFarPlaneRangeOfKeyframe(int argKeyframeFarPlane, int argProjectID, int argStartKeyFrame, int argEndKeyFrame)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                try
                {
                    //Update Keyframes
                    cnn.Execute("UPDATE Keyframes" +
                                " SET KeyframeFarPlane = @KeyframeFarPlane" +
                                " WHERE ProjectID_Ref = @ProjectID" +
                                " AND KeyframeNum BETWEEN @StartKeyFrame AND @EndKeyFrame",
                    param: new
                    {
                        @ProjectID = argProjectID,
                        @KeyframeFarPlane = argKeyframeFarPlane,
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
                    var lstKeyframes = cnn.Query<KeyframeModel>("SELECT ID,KeyframeNum" +
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

        public static void RecalculateKeyframeNumberingRange(int argProjectID, int argStartKeyframeNum)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    //Query for a list of all keyframes for the project ID
                    //This list is based on the start keyframe number argument in ascending order
                    var lstKeyframes = cnn.Query<KeyframeModel>("SELECT ID, KeyframeNum" +
                                      " FROM Keyframes" +
                                      " WHERE KeyframeNum > @StartKeyframeNum AND ProjectID_Ref = @ProjectID" +
                                      " ORDER BY KeyframeNum ASC",
                    param: new
                    {
                        @ProjectID = argProjectID,
                        @StartKeyframeNum = argStartKeyframeNum

                    });

                    //Create a variable with an initial value of the start keyframe number plus two.
                    //This renumbers the keyframes to allow the insertion of a new keyframe
                    //Example: Assume total keyframes is 21. If argStartKeyframeNum=18 then keyframes are renumbered as follows: 18->19, 19->20, 20->21, 21->22
                    int intRunningKeyframeNumber = argStartKeyframeNum+2;

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
                Program._MainForm.LogException("DAM RecalculateKeyframeNumberingRange", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ DAM RecalculateKeyframeNumberingRange. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                                                                 " FROM Keyframes as K LEFT JOIN Keyframe_Actions A ON K.ID = A.KeyframeID_Ref" +
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

        public static bool GetKeyframeActionNameExists(int argProjectID, int argKeyframeID, string argActioName)
        {
            try
            {
                int NoMoveActionsQuantity = 0;

                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {

                    //Get the count of Move Actions for the keyframe ID argument
                    NoMoveActionsQuantity = cnn.ExecuteScalar<int>("SELECT COUNT(A.ActionName)" +
                                                                 " FROM Keyframes as K LEFT JOIN Keyframe_Actions A ON K.ID = A.KeyframeID_Ref" +
                                                                 " WHERE K.ProjectID_Ref=@ProjectID AND K.ID = @KeyframeID AND A.ActionName = @ActionName",
                    param: new
                    {
                        @ActionName = argActioName,
                        @ProjectID = argProjectID,
                        @KeyframeID = argKeyframeID,
                    });
                }

                if (NoMoveActionsQuantity > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Program._MainForm.LogException("DAM GetKeyframeNoMoveActionsExists", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ DAM GetKeyframeNoMoveActionsExists. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
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
                                                                 " WHERE A.KeyframeID_Ref = @KeyframeID AND A.SendKeyChar <> @InsertCmd" +
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
                                                                 " FROM Keyframes as K LEFT JOIN Keyframe_Actions A ON K.ID = A.KeyframeID_Ref" +
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
                                                                 " FROM Keyframes as K LEFT JOIN Keyframe_Actions A ON K.ID = A.KeyframeID_Ref" +
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

        public static List<KeyframeActionsModel> GetKeyframeActionData(int argProjectID, int argKeyframeID, string argKeyframeAction)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    var output = cnn.Query<KeyframeActionsModel>("SELECT A.ID, A.ActionName, A.SendKeyChar, A.SendKeyQuantity, A.StepAngleCount" +
                                                                 " FROM Keyframes as K LEFT JOIN Keyframe_Actions A ON K.ID = A.KeyframeID_Ref" +
                                                                 " WHERE K.ProjectID_Ref=@ProjectID AND K.ID = @KeyframeID AND A.ActionName = @ActionName",
                    param: new
                    {
                        @ProjectID = argProjectID,
                        @KeyframeID = argKeyframeID,
                        @ActionName = argKeyframeAction
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

        public static void UpdateKeyframeAction(int argKeyframeID_Ref, KeyframeActionsModel itemKeyframeAction)
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
                        " WHERE KeyframeID_Ref = @KeyframeID_Ref AND ActionName = @ActionName",
                    param: new
                    {
                        @KeyframeID_Ref = argKeyframeID_Ref,
                        @ActionName = itemKeyframeAction.ActionName,
                        @SendKeyChar = itemKeyframeAction.SendKeyChar,
                        @SendKeyQuantity = itemKeyframeAction.SendKeyQuantity,
                        @StepAngleCount = itemKeyframeAction.StepAngleCount
                    });
                }
            }
            catch (Exception ex)
            {
                Program._MainForm.LogException("DAM UpdateKeyframeAction", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ DAM UpdateKeyframeAction. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void DeleteKeyframeAction(int argKeyframeID_Ref, KeyframeActionsModel itemKeyframeAction)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    cnn.Execute("DELETE FROM Keyframe_Actions " +
                                "WHERE KeyframeID_Ref = @KeyframeID_Ref AND ActionName = @ActionName",
                    param: new
                    {

                        @KeyframeID_Ref = argKeyframeID_Ref,
                        @ActionName = itemKeyframeAction.ActionName,
                        @SendKeyChar = itemKeyframeAction.SendKeyChar,
                        @SendKeyQuantity = itemKeyframeAction.SendKeyQuantity,
                        @StepAngleCount = itemKeyframeAction.StepAngleCount

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

                    var output = cnn.Query<KeyframeModel>("SELECT *" +
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
                    cnn.Execute("INSERT INTO Sequence_Steps(SequenceParent_ID, Step_Group, Step_Name, Step_AngleCount, Step_SendKey, Step_SendKeyQty) " +
                                "SELECT @SeqParentID, k.KeyframeNum, a.ActionName, a.StepAngleCount, a.SendKeyChar, a.SendKeyQuantity " +
                                "FROM Keyframes as k LEFT JOIN Keyframe_Actions a ON k.ID = a.KeyframeID_Ref " +
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
                    sb.Append("SELECT Step_ID, Step_Group, Step_Name, Step_AngleCount, Step_SendKey, Step_SendKeyQty ");
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

        public static void ManageSeqUpdateStep(int argStepID, int argStepGroup, string argStepName, int argSendKeyQtyUserEntry, string argStepSendKey, int argStepAngleCount)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    cnn.Execute("UPDATE Sequence_Steps" +
                        " SET Step_Group=@StepGroup," +
                        " Step_Name=@StepName," +
                        " Step_AngleCount=@StepAngleCount," +
                        " Step_SendKeyQty=@StepSendKeyQty," +
                        " Step_SendKey=@StepSendKey " +
                        " WHERE Step_ID = @StepID ",
                    param: new
                    {
                        @StepGroup = argStepGroup,
                        @StepName = argStepName,
                        @StepAngleCount = argStepAngleCount,
                        @StepSendKeyQty = argSendKeyQtyUserEntry,
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

        public static void ManageSeqAddMoveStep(int argSequenceParentID, int argStepGroup, string argMoveStepName, int argMoveStepAngleCount, string argMoveStepSendKey)
        {
            try
            {
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {
                    cnn.Execute("INSERT INTO Sequence_Steps " +
                                "(SequenceParent_ID," +
                                " Step_Group," +
                                " Step_Name," +
                                " Step_AngleCount," +
                                " Step_SendKey, " +
                                " Step_SendKeyQty) " +
                                "VALUES(@SequenceParentID," +
                                " @StepGroup," +
                                " @MoveStepName," +
                                " @MoveStepCountAngle," +
                                " @MoveStepSendKey," +
                                " @MoveSendKeyQty)",
                    param: new
                    {
                        @SequenceParentID = argSequenceParentID,
                        @StepGroup = argStepGroup,
                        @MoveStepName = argMoveStepName,
                        @MoveStepCountAngle = argMoveStepAngleCount,
                        @MoveStepSendKey = argMoveStepSendKey,
                        @MoveSendKeyQty = argMoveStepAngleCount,

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
                        cnn.Execute("UPDATE SQLITE_SEQUENCE SET SEQ = 0 WHERE NAME = 'Sequence_Steps'");

                        cnn.Execute("DELETE FROM Sequence_Parent");
                        cnn.Execute("UPDATE SQLITE_SEQUENCE SET SEQ = 0 WHERE NAME = 'Sequence_Parent'");
                    }

                    cnn.Execute("DELETE FROM Keyframe_Actions");
                    cnn.Execute("UPDATE SQLITE_SEQUENCE SET SEQ = 0 WHERE NAME = 'Keyframe_Actions'");

                    cnn.Execute("DELETE FROM Keyframes");
                    cnn.Execute("UPDATE SQLITE_SEQUENCE SET SEQ = 0 WHERE NAME = 'Keyframes'");

                    cnn.Execute("DELETE FROM Animation_Project");
                    cnn.Execute("UPDATE SQLITE_SEQUENCE SET SEQ = 0 WHERE NAME = 'Animation_Project'");
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

        public static bool CreateSampleAnimationProject(string argSampleProjectName)
        {
            try
            {
                //Delete the existing sample project record, keyframes and action records
                using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
                {

                    int ProjectID = 0;

                    //Get the ID of the existing sample project record
                    ProjectID = cnn.ExecuteScalar<int>("SELECT ID FROM Animation_Project WHERE Project_Name = @ProjectName",
                    param: new
                    {
                        @ProjectName = argSampleProjectName
                    });

                    //Delete all of the project's keyframe and keyframe actions
                    DeleteAllKeyframeAndKeyframeActions(ProjectID);

                    //Lastly, delete the project record
                    DeleteAnimationProject(ProjectID);
                }

                //Collect the data for a sample project record into a collection object
                Collection<ProjectModel> colProjectData = new Collection<ProjectModel>();
                colProjectData.Add(new ProjectModel());

                colProjectData[0].Project_Name = argSampleProjectName;
                colProjectData[0].Project_Notes = "This is a sample animation project for review and experimentation.";
                colProjectData[0].SlideWalk_StepCount = MainForm.cSlideWalkStepCountDefault;
                colProjectData[0].LookingRolling_Angle = MainForm.cLookingRollingAngleDefault;
                colProjectData[0].Frames_Between = MainForm.cFramesBetweenDefault;
                colProjectData[0].SendKeyDelay = MainForm.cKeyDelayDefault;
                colProjectData[0].Total_Frames_Count = 0;
                colProjectData[0].ProjectFarPlane = "500";
                colProjectData[0].Animation_Length_30 = "00:00";
                colProjectData[0].Animation_Length_60 = "00:00";
                colProjectData[0].M3PIFileLocation = string.Empty;
                colProjectData[0].M3AFileLocation = string.Empty;

                int SampleProjectID = InsertProjectData(colProjectData);

                //Insert sample keyframes if we have a parent project record
                if (SampleProjectID > 0)
                {

                    //These defined here to reduce the number of characters in the list add statements
                    string KT = MainForm.cKeyStackLineChar_Manual;
                    int FB = MainForm.cFramesBetweenDefault;
                    int FP = 500;

                    int SWC = MainForm.cSlideWalkStepCountDefault;
                    int LRA = MainForm.cLookingRollingAngleDefault;

                    //Create a temporary list to hold the sample keyframe data
                    List<SampleProjectKeyframesModel> lstSampleDataModel = new List<SampleProjectKeyframesModel>();

                    //Create a temporary list to hold the sample keyframe action data
                    List<SampleProjectActionsModel> lstKeyframeAction_temp = new List<SampleProjectActionsModel>();

                    //Notes:
                    //KeyframeNum is manually incremented here
                    //The value in KeyframeDisplay is made up
                    //FrameCount increments by the value of Frames Between
                    
                    //Walk forward
                    lstSampleDataModel.Add(new SampleProjectKeyframesModel() { SampleKeyframeID = 1, KeyframeType = KT, KeyframeNum = 1, KeyframeDisplay = GetKFDisplay("WF",1,SWC), FramesBetween = FB, FrameCount = 50, KeyframeFarPlane = FP, KeyframeApproved = false, KeyframeNote = "walk forward" });
                    lstKeyframeAction_temp.Add(new SampleProjectActionsModel() { SampleKeyframeID_Ref = 1, ActionName = "WF", SendKeyChar = "w", SendKeyQuantity = 1, StepAngleCount = 1 * SWC });

                    lstSampleDataModel.Add(new SampleProjectKeyframesModel() { SampleKeyframeID = 2, KeyframeType = KT, KeyframeNum = 2, KeyframeDisplay = GetKFDisplay("WF",1,SWC), FramesBetween = FB, FrameCount = 100, KeyframeFarPlane = FP, KeyframeApproved = false, KeyframeNote = "walk forward" });
                    lstKeyframeAction_temp.Add(new SampleProjectActionsModel() { SampleKeyframeID_Ref = 2, ActionName = "WF", SendKeyChar = "w", SendKeyQuantity = 1, StepAngleCount = 1 * SWC });

                    //Right banking turn
                    lstSampleDataModel.Add(new SampleProjectKeyframesModel() { SampleKeyframeID = 3, KeyframeType = KT, KeyframeNum = 3, KeyframeDisplay = string.Concat(GetKFDisplay("WF", 1, SWC), GetKFDisplay("LL", 2, LRA), GetKFDisplay("RCW", 1, LRA)), FramesBetween = FB, FrameCount = 150, KeyframeFarPlane = FP, KeyframeApproved = false, KeyframeNote = "starting banking right turn "});
                    lstKeyframeAction_temp.Add(new SampleProjectActionsModel() { SampleKeyframeID_Ref = 3, ActionName = "WF", SendKeyChar = "w", SendKeyQuantity = 1, StepAngleCount = 1 * SWC });
                    lstKeyframeAction_temp.Add(new SampleProjectActionsModel() { SampleKeyframeID_Ref = 3, ActionName = "LL", SendKeyChar = "i", SendKeyQuantity = 2, StepAngleCount = 2 * LRA });
                    lstKeyframeAction_temp.Add(new SampleProjectActionsModel() { SampleKeyframeID_Ref = 3, ActionName = "RCW", SendKeyChar = "u", SendKeyQuantity = 1, StepAngleCount = 1 * LRA });

                    lstSampleDataModel.Add(new SampleProjectKeyframesModel() { SampleKeyframeID = 4, KeyframeType = KT, KeyframeNum = 4, KeyframeDisplay = string.Concat(GetKFDisplay("WF", 1, SWC), GetKFDisplay("LL", 2, LRA), GetKFDisplay("RCW", 1, LRA)), FramesBetween = FB, FrameCount = 200, KeyframeFarPlane = FP, KeyframeApproved = false, KeyframeNote = "holding banking right turn " });
                    lstKeyframeAction_temp.Add(new SampleProjectActionsModel() { SampleKeyframeID_Ref = 4, ActionName = "WF", SendKeyChar = "w", SendKeyQuantity = 1, StepAngleCount = 1 * SWC });
                    lstKeyframeAction_temp.Add(new SampleProjectActionsModel() { SampleKeyframeID_Ref = 4, ActionName = "LL", SendKeyChar = "i", SendKeyQuantity = 2, StepAngleCount = 2 * LRA });
                    lstKeyframeAction_temp.Add(new SampleProjectActionsModel() { SampleKeyframeID_Ref = 4, ActionName = "RCW", SendKeyChar = "u", SendKeyQuantity = 1, StepAngleCount = 1 * LRA });

                    lstSampleDataModel.Add(new SampleProjectKeyframesModel() { SampleKeyframeID = 5, KeyframeType = KT, KeyframeNum = 5, KeyframeDisplay = string.Concat(GetKFDisplay("WF", 1, SWC), GetKFDisplay("LL", 2, LRA), GetKFDisplay("RCW", 1, LRA)), FramesBetween = FB, FrameCount = 250, KeyframeFarPlane = FP, KeyframeApproved = false, KeyframeNote = "holding banking right turn " });
                    lstKeyframeAction_temp.Add(new SampleProjectActionsModel() { SampleKeyframeID_Ref = 5, ActionName = "WF", SendKeyChar = "w", SendKeyQuantity = 1, StepAngleCount = 1 * SWC });
                    lstKeyframeAction_temp.Add(new SampleProjectActionsModel() { SampleKeyframeID_Ref = 5, ActionName = "LL", SendKeyChar = "i", SendKeyQuantity = 2, StepAngleCount = 2 * LRA });
                    lstKeyframeAction_temp.Add(new SampleProjectActionsModel() { SampleKeyframeID_Ref = 5, ActionName = "RCW", SendKeyChar = "u", SendKeyQuantity = 1, StepAngleCount = 1 * LRA });

                    //Leveling out right banking turn
                    lstSampleDataModel.Add(new SampleProjectKeyframesModel() { SampleKeyframeID = 6, KeyframeType = KT, KeyframeNum = 6, KeyframeDisplay = string.Concat(GetKFDisplay("WF", 1, SWC), GetKFDisplay("RCC", 1, LRA)), FramesBetween = FB, FrameCount = 300, KeyframeFarPlane = FP, KeyframeApproved = false, KeyframeNote = "leveling out from banking right turn " });
                    lstKeyframeAction_temp.Add(new SampleProjectActionsModel() { SampleKeyframeID_Ref = 6, ActionName = "WF", SendKeyChar = "w", SendKeyQuantity = 1, StepAngleCount = 1 * SWC });
                    lstKeyframeAction_temp.Add(new SampleProjectActionsModel() { SampleKeyframeID_Ref = 6, ActionName = "RCC", SendKeyChar = "o", SendKeyQuantity = 1, StepAngleCount = 1 * LRA });

                    lstSampleDataModel.Add(new SampleProjectKeyframesModel() { SampleKeyframeID = 7, KeyframeType = KT, KeyframeNum = 7, KeyframeDisplay = string.Concat(GetKFDisplay("WF", 1, SWC), GetKFDisplay("RCC", 1, LRA)), FramesBetween = FB, FrameCount = 350, KeyframeFarPlane = FP, KeyframeApproved = false, KeyframeNote = "cont leveling out from banking right turn " });
                    lstKeyframeAction_temp.Add(new SampleProjectActionsModel() { SampleKeyframeID_Ref = 7, ActionName = "WF", SendKeyChar = "w", SendKeyQuantity = 1, StepAngleCount = 1 * SWC });
                    lstKeyframeAction_temp.Add(new SampleProjectActionsModel() { SampleKeyframeID_Ref = 7, ActionName = "RCC", SendKeyChar = "o", SendKeyQuantity = 1, StepAngleCount = 1 * LRA });

                    lstSampleDataModel.Add(new SampleProjectKeyframesModel() { SampleKeyframeID = 8, KeyframeType = KT, KeyframeNum = 8, KeyframeDisplay = string.Concat(GetKFDisplay("WF", 1, SWC), GetKFDisplay("RCC", 1, LRA)), FramesBetween = FB, FrameCount = 400, KeyframeFarPlane = FP, KeyframeApproved = false, KeyframeNote = "cont leveling out from banking right turn " });
                    lstKeyframeAction_temp.Add(new SampleProjectActionsModel() { SampleKeyframeID_Ref = 8, ActionName = "WF", SendKeyChar = "w", SendKeyQuantity = 1, StepAngleCount = 1 * SWC });
                    lstKeyframeAction_temp.Add(new SampleProjectActionsModel() { SampleKeyframeID_Ref = 8, ActionName = "RCC", SendKeyChar = "o", SendKeyQuantity = 1, StepAngleCount = 1 * LRA });

                    //Resume walk forward
                    lstSampleDataModel.Add(new SampleProjectKeyframesModel() { SampleKeyframeID = 9, KeyframeType = KT, KeyframeNum = 9, KeyframeDisplay = GetKFDisplay("WF", 1, SWC), FramesBetween = FB, FrameCount = 450, KeyframeFarPlane = FP, KeyframeApproved = false, KeyframeNote = "turn ended, resuming walk forward" });
                    lstKeyframeAction_temp.Add(new SampleProjectActionsModel() { SampleKeyframeID_Ref = 9, ActionName = "WF", SendKeyChar = "w", SendKeyQuantity = 1, StepAngleCount = 1 * SWC });

                    lstSampleDataModel.Add(new SampleProjectKeyframesModel() { SampleKeyframeID = 10, KeyframeType = KT, KeyframeNum = 10, KeyframeDisplay = GetKFDisplay("WF", 1, SWC), FramesBetween = FB, FrameCount = 500, KeyframeFarPlane = FP, KeyframeApproved = false, KeyframeNote = "walk forward" });
                    lstKeyframeAction_temp.Add(new SampleProjectActionsModel() { SampleKeyframeID_Ref = 10, ActionName = "WF", SendKeyChar = "w", SendKeyQuantity = 1, StepAngleCount = 1*SWC });

                    //Insert the sample keyframe records defined above
                    KeyframeModel itemKeyframe = new KeyframeModel();
                    foreach (var itemKF in lstSampleDataModel)
                    {
                        itemKeyframe.KeyframeType = itemKF.KeyframeType;
                        itemKeyframe.KeyframeNum = itemKF.KeyframeNum;
                        itemKeyframe.KeyframeDisplay = itemKF.KeyframeDisplay;
                        itemKeyframe.FramesBetween = itemKF.FramesBetween;
                        itemKeyframe.FrameCount = itemKF.FrameCount;
                        itemKeyframe.KeyframeFarPlane = itemKF.KeyframeFarPlane;
                        itemKeyframe.KeyframeNote = itemKF.KeyframeNote;

                        //Insert into the DB which returns the ID of the newly inserted keyframe record
                        int KeyframeID = Data_Access_Methods.InsertKeyframeData(SampleProjectID, itemKeyframe);
                        if (KeyframeID > 0)
                        {
                            //Insert the sample keyframe actions as defined in lstKeyframeAction_temp list above
                            KeyframeActionsModel lstKeyframeAction = new KeyframeActionsModel();
                            foreach (var itemAct in lstKeyframeAction_temp)
                            {
                                if (itemAct.SampleKeyframeID_Ref == itemKF.SampleKeyframeID)
                                {
                                    lstKeyframeAction.ActionName = itemAct.ActionName;
                                    lstKeyframeAction.SendKeyChar = itemAct.SendKeyChar;
                                    lstKeyframeAction.SendKeyQuantity = itemAct.SendKeyQuantity;
                                    lstKeyframeAction.StepAngleCount = itemAct.StepAngleCount;

                                    InsertKeyframeActionData(KeyframeID, lstKeyframeAction);
                                }
                            }
                        }
                        else
                        {
                            //Something went wrong with the keyframe insert (zero was returned

                            //>>>>>>>>>>>>>>>>>>>>>> handle this
                        }

                    }

                }

                return true;
            }
            catch (Exception ex)
            {
                Program._MainForm.LogException("DAM CreateSampleAnimationProject", ex); //Log this error
                MessageBoxAdv.Show(ex.Message, "Error @ DAM CreateSampleAnimationProject. Error was logged.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private static string GetKFDisplay(string StepName, int StepCount, int StepAngleCount)
        {
            StringBuilder sb = new StringBuilder(); 
            sb.Append(StepName);
            sb.Append(StepCount.ToString());
            sb.Append(" (");
            sb.Append((StepCount*StepAngleCount).ToString());
            sb.Append(") ");

            return sb.ToString();
        }











    }

    #endregion
}
