using System;
using System.Collections;
using System.Data;
//using System.Xml.Linq;
using CmUtils = CommonUtils;
using TConst = Demo.Lab.Constants;
using TDALUtils = EzDAL.Utils;
using TError = Demo.Lab.Errors;
using TUtils = Demo.Lab.Utils;



namespace Demo.Lab.Biz
{
	public partial class BizDemoLab
	{
		#region // Aud_Campaign_CheckDB
		private void Aud_Campaign_CheckDB(
			ref ArrayList alParamsCoupleError
			, object objCampaignCode
			, string strFlagExistToCheck
			, string strFlagActiveListToCheck
			, out DataTable dtDB_Aud_Campaign
			)
		{
			// GetInfo:
			string strSqlExec = CmUtils.StringUtils.Replace(@"
					select top 1
						t.*
					from Aud_Campaign t --//[mylock]
					where (1=1)
						and t.CampaignCode = @objCampaignCode
					;
				");
			dtDB_Aud_Campaign = _cf.db.ExecQuery(
				strSqlExec
				, "@objCampaignCode", objCampaignCode
				).Tables[0];
			dtDB_Aud_Campaign.TableName = "Aud_Campaign";

			// strFlagExistToCheck:
			if (strFlagExistToCheck.Length > 0)
			{
				if (CmUtils.StringUtils.StringEqual(strFlagExistToCheck, TConst.Flag.Active) && dtDB_Aud_Campaign.Rows.Count < 1)
				{
					alParamsCoupleError.AddRange(new object[]{
						"Check.CampaignCode", objCampaignCode
						});
					throw CmUtils.CMyException.Raise(
						TError.ErrDemoLab.Aud_Campaign_CheckDB_CampainNotFound
						, null
						, alParamsCoupleError.ToArray()
						);
				}
				if (CmUtils.StringUtils.StringEqual(strFlagExistToCheck, TConst.Flag.Inactive) && dtDB_Aud_Campaign.Rows.Count > 0)
				{
					alParamsCoupleError.AddRange(new object[]{
						"Check.CampaignCode", objCampaignCode
						});
					throw CmUtils.CMyException.Raise(
						TError.ErrDemoLab.Aud_Campaign_CheckDB_CampainExist
						, null
						, alParamsCoupleError.ToArray()
						);
				}
			}

			// strFlagActiveListToCheck:
			if (strFlagActiveListToCheck.Length > 0 && !strFlagActiveListToCheck.Contains(Convert.ToString(dtDB_Aud_Campaign.Rows[0]["FlagActive"])))
			{
				alParamsCoupleError.AddRange(new object[]{
					"Check.CampaignCode", objCampaignCode
					, "Check.strFlagActiveListToCheck", strFlagActiveListToCheck
					, "DB.FlagActive", dtDB_Aud_Campaign.Rows[0]["FlagActive"]
					});
				throw CmUtils.CMyException.Raise(
					TError.ErrDemoLab.Aud_Campaign_CheckDB_FlagActiveNotMatched
					, null
					, alParamsCoupleError.ToArray()
					);
			}
		}
		#endregion

		#region // Mst_CriteriaScoreVersion_CheckDB
		private void Mst_CriteriaScoreVersion_CheckDB(
			ref ArrayList alParamsCoupleError
			, object objCrtrScoreVerCode
			, string strFlagExistToCheck
			, string strFlagActiveListToCheck
			, out DataTable dtDB_Mst_CriteriaScoreVersion
			)
		{
			// GetInfo:
			string strSqlExec = CmUtils.StringUtils.Replace(@"
					select top 1
						t.*
					from Mst_CriteriaScoreVersion t --//[mylock]
					where (1=1)
						and t.CrtrScoreVerCode = @objCrtrScoreVerCode
					;
				");
			dtDB_Mst_CriteriaScoreVersion = _cf.db.ExecQuery(
				strSqlExec
				, "@objCrtrScoreVerCode", objCrtrScoreVerCode
				).Tables[0];
			dtDB_Mst_CriteriaScoreVersion.TableName = "Mst_CriteriaScoreVersion";

			// strFlagExistToCheck:
			if (strFlagExistToCheck.Length > 0)
			{
				if (CmUtils.StringUtils.StringEqual(strFlagExistToCheck, TConst.Flag.Active) && dtDB_Mst_CriteriaScoreVersion.Rows.Count < 1)
				{
					alParamsCoupleError.AddRange(new object[]{
						"Check.CrtrScoreVerCode", objCrtrScoreVerCode
						});
					throw CmUtils.CMyException.Raise(
						TError.ErrDemoLab.Mst_CriteriaScoreVersion_CheckDB_CriteriaScoreVersionNotFound
						, null
						, alParamsCoupleError.ToArray()
						);
				}
				if (CmUtils.StringUtils.StringEqual(strFlagExistToCheck, TConst.Flag.Inactive) && dtDB_Mst_CriteriaScoreVersion.Rows.Count > 0)
				{
					alParamsCoupleError.AddRange(new object[]{
						"Check.CrtrScoreVerCode", objCrtrScoreVerCode
						});
					throw CmUtils.CMyException.Raise(
						TError.ErrDemoLab.Mst_CriteriaScoreVersion_CheckDB_CriteriaScoreVersionExist
						, null
						, alParamsCoupleError.ToArray()
						);
				}
			}

			// strFlagActiveListToCheck:
			if (strFlagActiveListToCheck.Length > 0 && !strFlagActiveListToCheck.Contains(Convert.ToString(dtDB_Mst_CriteriaScoreVersion.Rows[0]["FlagActive"])))
			{
				alParamsCoupleError.AddRange(new object[]{
					"Check.CrtrScoreVerCode", objCrtrScoreVerCode
					, "Check.strFlagActiveListToCheck", strFlagActiveListToCheck
					, "DB.FlagActive", dtDB_Mst_CriteriaScoreVersion.Rows[0]["FlagActive"]
					});
				throw CmUtils.CMyException.Raise(
					TError.ErrDemoLab.Mst_CriteriaScoreVersion_CheckDB_FlagActiveNotMatched
					, null
					, alParamsCoupleError.ToArray()
					);
			}
		}
		#endregion

		#region // Mst_CriteriaScoreVersionAuditUser_CheckDB
		private void Mst_CriteriaScoreVersionAuditUser_CheckDB(
			ref ArrayList alParamsCoupleError
			, object objCrtrScoreVerAUCode
			, string strFlagExistToCheck
			, string strFlagActiveListToCheck
			, out DataTable dtDB_Mst_CriteriaScoreVersionAuditUser
			)
		{
			// GetInfo:
			string strSqlExec = CmUtils.StringUtils.Replace(@"
					select top 1
						t.*
					from Mst_CriteriaScoreVersionAuditUser t --//[mylock]
					where (1=1)
						and t.CrtrScoreVerAUCode = @objCrtrScoreVerAUCode
					;
				");
			dtDB_Mst_CriteriaScoreVersionAuditUser = _cf.db.ExecQuery(
				strSqlExec
				, "@objCrtrScoreVerAUCode", objCrtrScoreVerAUCode
				).Tables[0];
			dtDB_Mst_CriteriaScoreVersionAuditUser.TableName = "Mst_CriteriaScoreVersionAuditUser";

			// strFlagExistToCheck:
			if (strFlagExistToCheck.Length > 0)
			{
				if (CmUtils.StringUtils.StringEqual(strFlagExistToCheck, TConst.Flag.Active) && dtDB_Mst_CriteriaScoreVersionAuditUser.Rows.Count < 1)
				{
					alParamsCoupleError.AddRange(new object[]{
						"Check.CrtrScoreVerAUCode", objCrtrScoreVerAUCode
						});
					throw CmUtils.CMyException.Raise(
						TError.ErrDemoLab.Mst_CriteriaScoreVersionAuditUser_CheckDB_CriteriaScoreVersionAuditUserNotFound
						, null
						, alParamsCoupleError.ToArray()
						);
				}
				if (CmUtils.StringUtils.StringEqual(strFlagExistToCheck, TConst.Flag.Inactive) && dtDB_Mst_CriteriaScoreVersionAuditUser.Rows.Count > 0)
				{
					alParamsCoupleError.AddRange(new object[]{
						"Check.CrtrScoreVerAUCode", objCrtrScoreVerAUCode
						});
					throw CmUtils.CMyException.Raise(
						TError.ErrDemoLab.Mst_CriteriaScoreVersionAuditUser_CheckDB_CriteriaScoreVersionAuditUserExist
						, null
						, alParamsCoupleError.ToArray()
						);
				}
			}

			// strFlagActiveListToCheck:
			if (strFlagActiveListToCheck.Length > 0 && !strFlagActiveListToCheck.Contains(Convert.ToString(dtDB_Mst_CriteriaScoreVersionAuditUser.Rows[0]["FlagActive"])))
			{
				alParamsCoupleError.AddRange(new object[]{
					"Check.CrtrScoreVerAUCode", objCrtrScoreVerAUCode
					, "Check.strFlagActiveListToCheck", strFlagActiveListToCheck
					, "DB.FlagActive", dtDB_Mst_CriteriaScoreVersionAuditUser.Rows[0]["FlagActive"]
					});
				throw CmUtils.CMyException.Raise(
					TError.ErrDemoLab.Mst_CriteriaScoreVersionAuditUser_CheckDB_FlagActiveNotMatched
					, null
					, alParamsCoupleError.ToArray()
					);
			}
		}
		#endregion

		#region // Aud_Campaign_Save
		public DataSet Aud_Campaign_Save(
			string strTid
			, DataRow drSession
			////
			, object objFlagIsDelete
			////
			, object objCampaignCode
			, object objCampaignCrCode
			, object objCrtrScoreVerCode
			, object objCrtrScoreVerAUCode
			, object objCampaignName
			, object objEffDTimeStart
			, object objEffDTimeEnd
			, object objQtyCheck
			, object objQtySuccess
			, object objMinIntervalDays
			, object objReportEndDate
			, object[] arrobjDSData
			)
		{
			#region // Temp:
			DataSet mdsFinal = CmUtils.CMyDataSet.NewMyDataSet(strTid);
			//int nTidSeq = 0;
			bool bMyDebugSql = false;
			DateTime dtimeSys = DateTime.Now;
			bool bNeedTransaction = true;
			string strFunctionName = "Aud_Campaign_Save";
			string strErrorCodeDefault = TError.ErrDemoLab.Aud_Campaign_Save;
			ArrayList alParamsCoupleError = new ArrayList(new object[]{
					"strFunctionName", strFunctionName
					, "dtimeSys", dtimeSys.ToString("yyyy-MM-dd HH:mm:ss")
					////
					, "objFlagIsDelete", objFlagIsDelete
					////
					, "objCampaignCode", objCampaignCode
					, "objCampaignCrCode", objCampaignCrCode
					, "objCrtrScoreVerCode", objCrtrScoreVerCode
					, "objCrtrScoreVerAUCode", objCrtrScoreVerAUCode
					, "objCampaignName", objCampaignName
					, "objEffDTimeStart", objEffDTimeStart
					, "objEffDTimeEnd", objEffDTimeEnd
					, "objQtyCheck", objQtyCheck
					, "objQtySuccess", objQtySuccess
					, "objMinIntervalDays", objMinIntervalDays
					, "objReportEndDate", objReportEndDate
					});
			//ArrayList alPCErrEx = new ArrayList();
			#endregion

			try
			{
				#region // Convert Input:
				DataSet dsData = TUtils.CUtils.StdDS(arrobjDSData);
				if (dsData == null) dsData = new DataSet("dsData");
				dsData.AcceptChanges();
				alParamsCoupleError.AddRange(new object[]{
					 "Check.dsData", CmUtils.XmlUtils.DataSet2XmlSimple(dsData)
					 });
				#endregion

				#region // Init:
				_cf.db.LogUserId = _cf.sinf.strUserCode;
				if (bNeedTransaction) _cf.db.BeginTransaction();

				// Write RequestLog:
				_cf.ProcessBizReq(
					strTid // strTid
					, strFunctionName // strFunctionName
					, alParamsCoupleError // alParamsCoupleError
					);

				// Check Access/Deny:
				Sys_Access_CheckDeny(
					ref alParamsCoupleError
					, strFunctionName
					);

				#endregion

				#region //// Refine and Check Aud_Campaign:
				////
				bool bIsDelete = CmUtils.StringUtils.StringEqual(objFlagIsDelete, TConst.Flag.Active);
				////
				string strCampaignCode = TUtils.CUtils.StdParam(objCampaignCode);
				string strCampaignCrCode = TUtils.CUtils.StdParam(objCampaignCrCode);
				string strCrtrScoreVerCode = string.Format("{0}", objCrtrScoreVerCode).Trim().ToUpper();
				string strCrtrScoreVerAUCode = string.Format("{0}", objCrtrScoreVerAUCode).Trim().ToUpper();
				string strCampaignName = string.Format("{0}", objCampaignName).Trim();
				string strEffDTimeStart = TUtils.CUtils.StdDTimeBeginDay(objEffDTimeStart);
				string strEffDTimeEnd = TUtils.CUtils.StdDTimeEndDay(objEffDTimeEnd);
				int intQtyCheck = Convert.ToInt32(TUtils.CUtils.StdInt(objQtyCheck));
				int intQtySuccess = Convert.ToInt32(TUtils.CUtils.StdInt(objQtySuccess));
				int intMinIntervalDays = Convert.ToInt32(TUtils.CUtils.StdInt(objMinIntervalDays));
				int intReportEndDate = Convert.ToInt32(TUtils.CUtils.StdInt(objReportEndDate));
				int intMinImagesPerCheck = 1;
				int intMaxImagesPerCheck = 1000;
				string strCreateDTime = null;
				string strCreateBy = null;

				////
				DataTable dtDB_Aud_Campaign = null;
				{

					Aud_Campaign_CheckDB(
						ref alParamsCoupleError // alParamsCoupleError
						, strCampaignCode // objCampaignCode
						, "" // strFlagExistToCheck
						, "" // strStatusListToCheck
						, out dtDB_Aud_Campaign // dtDB_Aud_Campaign
						);
					if (dtDB_Aud_Campaign.Rows.Count < 1) // Chưa Tồn tại Order.
					{
						if (bIsDelete)
						{
							goto MyCodeLabel_Done; // Thành công.
						}
						else
						{
							// Nothing.
						}
					}
					else // Đã Tồn tại.
					{
						if (!CmUtils.StringUtils.StringEqualIgnoreCase(dtDB_Aud_Campaign.Rows[0]["CampaignStatus"], TConst.CampaignStatus.Pending))
						{
							alParamsCoupleError.AddRange(new object[]{
								"Check.DB.CampaignStatus", dtDB_Aud_Campaign.Rows[0]["CampaignStatus"]
								, "Check.CampaignStatus.Expected", TConst.CampaignStatus.Pending
							});
							throw CmUtils.CMyException.Raise(
								TError.ErrDemoLab.Aud_Campaign_Save_InvalidCampaignStatus
								, null
								, alParamsCoupleError.ToArray()
								);
						}
						else
						{
							strCreateDTime = TUtils.CUtils.StdDTime(dtDB_Aud_Campaign.Rows[0]["CreateDTime"]);
							strCreateBy = TUtils.CUtils.StdParam(dtDB_Aud_Campaign.Rows[0]["CreateBy"]);
						}
					}
					////
					strCreateDTime = string.IsNullOrEmpty(strCreateDTime) ? dtimeSys.ToString("yyyy-MM-dd HH:mm:ss") : strCreateDTime;
					strCreateBy = string.IsNullOrEmpty(strCreateBy) ? _cf.sinf.strUserCode : strCreateBy;
					////
					if (strCampaignCrCode == null || strCampaignCrCode.Length < 1)
					{
						alParamsCoupleError.AddRange(new object[]{
							"Check.strCampaignCrCode", strCampaignCrCode
							});
						throw CmUtils.CMyException.Raise(
							TError.ErrDemoLab.Aud_Campaign_Save_InvalidCampaignCrCode
							, null
							, alParamsCoupleError.ToArray()
							);
					}
					////
					DataTable dtDB_Mst_CampainCriteria = null;

					Mst_CampainCriteria_CheckDB(
						ref alParamsCoupleError // alParamsCoupleError
						, strCampaignCrCode // objCampaignCrCode
						, TConst.Flag.Yes // strFlagExistToCheck
						, TConst.Flag.Yes // strStatusListToCheck
						, out dtDB_Mst_CampainCriteria // dtDB_Mst_CampainCriteria
						);
					////
					DataTable dtDB_Mst_CriteriaScoreVersion = null;

					Mst_CriteriaScoreVersion_CheckDB(
						ref alParamsCoupleError // alParamsCoupleError
						, strCrtrScoreVerCode // objCrtrScoreVerCode
						, TConst.Flag.Yes // strFlagExistToCheck
						, "" // strStatusListToCheck
						, out dtDB_Mst_CriteriaScoreVersion // dtDB_Mst_CriteriaScoreVersion
						);
					////
					DataTable dtDB_Mst_CriteriaScoreVersionAuditUser = null;

					Mst_CriteriaScoreVersionAuditUser_CheckDB(
						ref alParamsCoupleError // alParamsCoupleError
						, strCrtrScoreVerAUCode // objCampaignCrCode
						, TConst.Flag.Yes // strFlagExistToCheck
						, "" // strStatusListToCheck
						, out dtDB_Mst_CriteriaScoreVersionAuditUser // dtDB_Mst_CriteriaScoreVersionAuditUser
						);
					////
					if (strCampaignName == null || strCampaignName.Length < 1)
					{
						alParamsCoupleError.AddRange(new object[]{
							"Check.strCampaignName", strCampaignName
							});
						throw CmUtils.CMyException.Raise(
							TError.ErrDemoLab.Aud_Campaign_Save_InvalidCampaignName
							, null
							, alParamsCoupleError.ToArray()
							);
					}
					////
					if (strEffDTimeStart == null || strEffDTimeStart.Length < 1)
					{
						alParamsCoupleError.AddRange(new object[]{
							"Check.strEffDTimeStart", strEffDTimeStart
							});
						throw CmUtils.CMyException.Raise(
							TError.ErrDemoLab.Aud_Campaign_Save_InvalidEffDTimeStart
							, null
							, alParamsCoupleError.ToArray()
							);
					}
					////
					if (strEffDTimeEnd == null || strEffDTimeEnd.Length < 1)
					{
						alParamsCoupleError.AddRange(new object[]{
							"Check.strEffDTimeEnd", strEffDTimeEnd
							});
						throw CmUtils.CMyException.Raise(
							TError.ErrDemoLab.Aud_Campaign_Save_InvalidEffDTimeEnd
							, null
							, alParamsCoupleError.ToArray()
							);
					}
					//// 
					if (intQtyCheck < 0)
					{
						alParamsCoupleError.AddRange(new object[]{
							"Check.QtyCheck", intQtyCheck
							});
						throw CmUtils.CMyException.Raise(
							TError.ErrDemoLab.Aud_Campaign_Save_InvalidValue
							, null
							, alParamsCoupleError.ToArray()
							);
					}
					//// 
					if (intQtySuccess < 0)
					{
						alParamsCoupleError.AddRange(new object[]{
							"Check.QtySuccess", intQtySuccess
							});
						throw CmUtils.CMyException.Raise(
							TError.ErrDemoLab.Aud_Campaign_Save_InvalidValue
							, null
							, alParamsCoupleError.ToArray()
							);
					}
					//// 
					if (intMinIntervalDays < 1)
					{
						alParamsCoupleError.AddRange(new object[]{
							"Check.MinIntervalDays", intMinIntervalDays
							});
						throw CmUtils.CMyException.Raise(
							TError.ErrDemoLab.Aud_Campaign_Save_InvalidMinIntervalDays
							, null
							, alParamsCoupleError.ToArray()
							);
					}
					////
					if (intReportEndDate < 1)
					{
						alParamsCoupleError.AddRange(new object[]{
							"Check.ReportEndDate", intReportEndDate
							});
						throw CmUtils.CMyException.Raise(
							TError.ErrDemoLab.Aud_Campaign_Save_InvalidReportEndDate
							, null
							, alParamsCoupleError.ToArray()
							);
					}
				}
				////
				#endregion

				#region //// SaveTemp Aud_Campaign:
				if (!bIsDelete)
				{
					TUtils.CUtils.MyBuildDBDT_Common(
						_cf.db
						, "#input_Aud_Campaign"
						, new object[]{
							"CampaignCode", TConst.BizMix.Default_DBColType,
							"CampaignCrCode", TConst.BizMix.Default_DBColType,
							"CrtrScoreVerCode", TConst.BizMix.Default_DBColType,
							"CrtrScoreVerAUCode", TConst.BizMix.Default_DBColType,
							"CampaignName", TConst.BizMix.Default_DBColType,
							"EffDTimeStart", TConst.BizMix.Default_DBColType,
							"EffDTimeEnd", TConst.BizMix.Default_DBColType,
							"CreateDTime", TConst.BizMix.Default_DBColType,
							"CreateBy", TConst.BizMix.Default_DBColType,
							"QtyCheck", "int",
							"QtySuccess", "int",
							"MinIntervalDays", "int",
							"MinImagesPerCheck", "int",
							"MaxImagesPerCheck", "int",
							"ReportEndDate", "int",
							"Appr1DTime", TConst.BizMix.Default_DBColType,
							"Appr1By", TConst.BizMix.Default_DBColType,
							"Appr2DTime", TConst.BizMix.Default_DBColType,
							"Appr2By", TConst.BizMix.Default_DBColType,
							"FinishDTime", TConst.BizMix.Default_DBColType,
							"FinishBy", TConst.BizMix.Default_DBColType,
							"CancelDTime", TConst.BizMix.Default_DBColType,
							"CancelBy", TConst.BizMix.Default_DBColType,
							"CampaignStatus", TConst.BizMix.Default_DBColType,
							"Remark", TConst.BizMix.Default_DBColType,
							"LogLUDTime", TConst.BizMix.Default_DBColType,
							"LogLUBy", TConst.BizMix.Default_DBColType,
							}
						, new object[]{
							new object[]{
								strCampaignCode, // CampaignCode   
								strCampaignCrCode, // CampaignCrCode   
								strCrtrScoreVerCode, // CrtrScoreVerCode   
								strCrtrScoreVerAUCode, // CrtrScoreVerAUCode   
								strCampaignName, // CampaignName   
								strEffDTimeStart, // EffDTimeStart   
								strEffDTimeEnd, // EffDTimeEnd   
								strCreateDTime, // CreateDTime   
								strCreateBy, // CreateBy   
								intQtyCheck, // QtyCheck   
								intQtySuccess, // QtySuccess   
								intMinIntervalDays, // MinIntervalDays  
								intMinImagesPerCheck, // MinImagesPerCheck  
								intMaxImagesPerCheck, // MaxImagesPerCheck   
								intReportEndDate, // ReportEndDate   
								null, // Appr1DTime
								null, // Appr1By
								null, // Appr2DTime
								null, // Appr2By
								null, // FinishDTime
								null, // FinishBy
								null, // CancelDTime
								null, // CancelBy
								TConst.CampaignStatus.Pending, // CampaignStatus   
								null, // Remark
								dtimeSys.ToString("yyyy-MM-dd HH:mm:ss"), // LogLUDTime
						        _cf.sinf.strUserCode, // LogLUBy
						        }
							}
						);
				}
				#endregion

				#region //// Refine and Check Aud_CampaignDoc:
				////
				DataTable dtInput_Aud_CampaignDoc = null;
				if (!bIsDelete)
				{
					////
					string strTableCheck = "Aud_CampaignDoc";
					////
					if (!dsData.Tables.Contains(strTableCheck))
					{
						alParamsCoupleError.AddRange(new object[]{
							"Check.TableName", strTableCheck
							});
						throw CmUtils.CMyException.Raise(
							TError.ErrDemoLab.Aud_CampaignDoc_Save_Input_CampaignDocTblNotFound
							, null
							, alParamsCoupleError.ToArray()
							);
					}
					dtInput_Aud_CampaignDoc = dsData.Tables[strTableCheck];
					////
					TUtils.CUtils.StdDataInTable(
						dtInput_Aud_CampaignDoc         // dtData
						, "StdParam", "FilePath"        // arrstrCouple   
						);
					////

					TUtils.CUtils.MyForceNewColumn(ref dtInput_Aud_CampaignDoc, "CampaignCode", typeof(object));
					TUtils.CUtils.MyForceNewColumn(ref dtInput_Aud_CampaignDoc, "CreateDTime", typeof(object));
					TUtils.CUtils.MyForceNewColumn(ref dtInput_Aud_CampaignDoc, "CreateBy", typeof(object));
					TUtils.CUtils.MyForceNewColumn(ref dtInput_Aud_CampaignDoc, "LogLUDTime", typeof(object));
					TUtils.CUtils.MyForceNewColumn(ref dtInput_Aud_CampaignDoc, "LogLUBy", typeof(object));
					////
					for (int nScan = 0; nScan < dtInput_Aud_CampaignDoc.Rows.Count; nScan++)
					{
						////
						DataRow drScan = dtInput_Aud_CampaignDoc.Rows[nScan];

						string strFilePath = string.Format("{0}", drScan["FilePath"]).Trim();
						if (strFilePath.Length < 1)
						{
							alParamsCoupleError.AddRange(new object[]{
								"Check.strFilePath", strFilePath
								});
							throw CmUtils.CMyException.Raise(
								TError.ErrDemoLab.Aud_CampaignDoc_Save_InvalidFilePath
								, null
								, alParamsCoupleError.ToArray()
								);
						}

						////
						drScan["CampaignCode"] = strCampaignCode;
						drScan["CreateDTime"] = strCreateDTime;
						drScan["CreateBy"] = strCreateBy;
						drScan["LogLUDTime"] = dtimeSys.ToString("yyyy-MM-dd HH:mm:ss");
						drScan["LogLUBy"] = _cf.sinf.strUserCode;
						////
					}
				}
				#endregion

				#region //// SaveTemp Aud_CampaignDoc:
				if (!bIsDelete)
				{
					TUtils.CUtils.MyBuildDBDT_Common(
						_cf.db
						, "#input_Aud_CampaignDoc"
						, new object[]{
							"CampaignCode", TConst.BizMix.Default_DBColType,
							"FilePath", TConst.BizMix.Default_DBColType,
							"CreateDTime", TConst.BizMix.Default_DBColType,
							"CreateBy", TConst.BizMix.Default_DBColType,
							"LogLUDTime", TConst.BizMix.Default_DBColType,
							"LogLUBy", TConst.BizMix.Default_DBColType,
							}
						, dtInput_Aud_CampaignDoc
						);
				}
				#endregion

				#region //// Refine and Check Aud_CampaignDBPOSMDtl:
				////
				DataTable dtInput_Aud_CampaignDBPOSMDtl = null;
				if (!bIsDelete)
				{
					////
					string strTableCheck = "Aud_CampaignDBPOSMDtl";
					////
					if (!dsData.Tables.Contains(strTableCheck))
					{
						alParamsCoupleError.AddRange(new object[]{
							"Check.TableName", strTableCheck
							});
						throw CmUtils.CMyException.Raise(
							TError.ErrDemoLab.Aud_CampaignDBPOSMDtl_Save_Input_CampaignDBDtlTblNotFound
							, null
							, alParamsCoupleError.ToArray()
							);
					}
					dtInput_Aud_CampaignDBPOSMDtl = dsData.Tables[strTableCheck];
					////
					TUtils.CUtils.StdDataInTable(
						dtInput_Aud_CampaignDBPOSMDtl // dtData
						, "StdParam", "DBCode" // arrstrCouple   
						, "StdParam", "POSMCode" // arrstrCouple   
						, "StdParam", "QtyDeliver" // arrstrCouple   
						);
					////

					TUtils.CUtils.MyForceNewColumn(ref dtInput_Aud_CampaignDBPOSMDtl, "CampaignCode", typeof(object));
					TUtils.CUtils.MyForceNewColumn(ref dtInput_Aud_CampaignDBPOSMDtl, "QtyRetrieve", typeof(object));
					TUtils.CUtils.MyForceNewColumn(ref dtInput_Aud_CampaignDBPOSMDtl, "DateDBRetrieve", typeof(object));
					TUtils.CUtils.MyForceNewColumn(ref dtInput_Aud_CampaignDBPOSMDtl, "FlagActive", typeof(object));
					TUtils.CUtils.MyForceNewColumn(ref dtInput_Aud_CampaignDBPOSMDtl, "LogLUDTime", typeof(object));
					TUtils.CUtils.MyForceNewColumn(ref dtInput_Aud_CampaignDBPOSMDtl, "LogLUBy", typeof(object));
					////
					for (int nScan = 0; nScan < dtInput_Aud_CampaignDBPOSMDtl.Rows.Count; nScan++)
					{
						////
						DataRow drScan = dtInput_Aud_CampaignDBPOSMDtl.Rows[nScan];

						////
						DataTable dtDB_Mst_POSM = null;

						Mst_POSM_CheckDB(
							ref alParamsCoupleError // alParamsCoupleError
							, drScan["POSMCode"] // drScan["POSMCode"]
							, TConst.Flag.Yes // strFlagExistToCheck
							, "" // strStatusListToCheck
							, out dtDB_Mst_POSM // dtDB_Mst_POSM
							);
						////
						DataTable dtDB_Mst_Distributor = null;

						Mst_Distributor_CheckDB(
							ref alParamsCoupleError // alParamsCoupleError
							, drScan["DBCode"] // drScan["DBCode"]
							, TConst.Flag.Yes // strFlagExistToCheck
							, "" // strStatusListToCheck
							, out dtDB_Mst_Distributor // dtDB_Mst_Distributor
							);
						//// dbQtyDeliver >= 0
						double dbQtyDeliver = Convert.ToDouble(drScan["QtyDeliver"]);
						if (dbQtyDeliver <= 0.0)
						{
							alParamsCoupleError.AddRange(new object[]{
								"Check.dbQtyDeliver", dbQtyDeliver
								});
							throw CmUtils.CMyException.Raise(
								TError.ErrDemoLab.Aud_CampaignDBPOSMDtl_Save_InvalidValue
								, null
								, alParamsCoupleError.ToArray()
								);
						}

						////
						drScan["CampaignCode"] = strCampaignCode;
						drScan["QtyRetrieve"] = 0;
						drScan["DateDBRetrieve"] = null;
						drScan["FlagActive"] = TConst.Flag.Active;
						drScan["LogLUDTime"] = dtimeSys.ToString("yyyy-MM-dd HH:mm:ss");
						drScan["LogLUBy"] = _cf.sinf.strUserCode;
						////
					}
				}
				#endregion

				#region //// SaveTemp Aud_CampaignDBPOSMDtl:
				if (!bIsDelete)
				{
					TUtils.CUtils.MyBuildDBDT_Common(
						_cf.db
						, "#input_Aud_CampaignDBPOSMDtl"
						, new object[]{
							"CampaignCode", TConst.BizMix.Default_DBColType,
							"DBCode", TConst.BizMix.Default_DBColType,
							"POSMCode", TConst.BizMix.Default_DBColType,
							"QtyDeliver", "float",
							"QtyRetrieve", "float",
							"DateDBRetrieve", TConst.BizMix.Default_DBColType,
							"FlagActive", TConst.BizMix.Default_DBColType,
							"LogLUDTime", TConst.BizMix.Default_DBColType,
							"LogLUBy", TConst.BizMix.Default_DBColType,
							}
						, dtInput_Aud_CampaignDBPOSMDtl
						);
				}
				#endregion

				#region //// SaveTemp Aud_CampaignDBDtl:
				if (!bIsDelete)
				{
					DataTable dtInput_Aud_CampaignDBDtl = null;

					string strSql_TempTbl = CmUtils.StringUtils.Replace(@"
						select distinct
							CampaignCode
							, DBCode
							, '@strCampaignDBStatusDtl' CampaignDBStatusDtl
							, LogLUDTime
							, LogLUBy
						into #input_Aud_CampaignDBDtl_Temp
						from #input_Aud_CampaignDBPOSMDtl
						where (1=1)
						;
						select * from #input_Aud_CampaignDBDtl_Temp t --//[mylock]
						; 
					"
					, "@strCampaignDBStatusDtl", TConst.Flag.Active
					);

					dtInput_Aud_CampaignDBDtl = _cf.db.ExecQuery(strSql_TempTbl).Tables[0];

					TUtils.CUtils.MyBuildDBDT_Common(
						_cf.db
						, "#input_Aud_CampaignDBDtl"
						, new object[]{
							"CampaignCode", TConst.BizMix.Default_DBColType,
							"DBCode", TConst.BizMix.Default_DBColType,
							"CampaignDBStatusDtl", TConst.BizMix.Default_DBColType,
							"LogLUDTime", TConst.BizMix.Default_DBColType,
							"LogLUBy", TConst.BizMix.Default_DBColType,
							}
						, dtInput_Aud_CampaignDBDtl
						);
				}
				#endregion

				#region //// Save
				//// Clear All:
				{
					string strSqlDelete = CmUtils.StringUtils.Replace(@"
								---- Aud_CampaignDoc:
						        delete t
						        from Aud_CampaignDoc t --//[mylock]
						        where (1=1)
							        and t.CampaignCode = @strCampaignCode
						        ;  

								---- Aud_CampaignDBPOSMDtl:
						        delete t
						        from Aud_CampaignDBPOSMDtl t --//[mylock]
						        where (1=1)
							        and t.CampaignCode = @strCampaignCode 
						        ; 

								---- Aud_CampaignDBDtl:
						        delete t
						        from Aud_CampaignDBDtl t --//[mylock]
						        where (1=1)
							        and t.CampaignCode = @strCampaignCode 
								; 

								---- Aud_Campaign:
						        delete t
						        from Aud_Campaign t --//[mylock]
						        where (1=1)
							        and t.CampaignCode = @strCampaignCode
						        ;

					        ");
					_cf.db.ExecQuery(
						strSqlDelete
						, "@strCampaignCode", strCampaignCode
						);
				}
				//// Insert All:
				if (!bIsDelete)
				{
					////
					string zzzzClauseInsert_Aud_Campaign_zSave = CmUtils.StringUtils.Replace(@"
					        ---- Aud_Campaign:
					        insert into Aud_Campaign
					        (
						        CampaignCode 
								, CampaignCrCode 
								, CrtrScoreVerCode 
								, CrtrScoreVerAUCode 
								, CampaignName 
								, EffDTimeStart 
								, EffDTimeEnd 
								, CreateDTime 
								, CreateBy 
								, QtyCheck 
								, QtySuccess 
								, MinIntervalDays
								, MinImagesPerCheck
								, MaxImagesPerCheck 
								, ReportEndDate 
								, Appr1DTime 
								, Appr1By 
								, Appr2DTime 
								, Appr2By 
								, FinishDTime 
								, FinishBy 
								, CancelDTime 
								, CancelBy 
								, CampaignStatus 
								, Remark 
						        , LogLUDTime
						        , LogLUBy
					        )
					        select 
						        t.CampaignCode 
								, t.CampaignCrCode 
								, t.CrtrScoreVerCode 
								, t.CrtrScoreVerAUCode 
								, t.CampaignName 
								, t.EffDTimeStart 
								, t.EffDTimeEnd 
								, t.CreateDTime 
								, t.CreateBy 
								, t.QtyCheck 
								, t.QtySuccess 
								, t.MinIntervalDays
								, t.MinImagesPerCheck
								, t.MaxImagesPerCheck 
								, t.ReportEndDate 
								, t.Appr1DTime 
								, t.Appr1By 
								, t.Appr2DTime 
								, t.Appr2By 
								, t.FinishDTime 
								, t.FinishBy 
								, t.CancelDTime 
								, t.CancelBy 
								, t.CampaignStatus 
								, t.Remark 
								, t.LogLUDTime
								, t.LogLUBy
					        from #input_Aud_Campaign t --//[mylock]
					        ;
				        ");
					////
					string zzzzClauseInsert_Aud_CampaignDoc_zSave = CmUtils.StringUtils.Replace(@"
					        ---- Aud_CampaignDoc:
					        insert into Aud_CampaignDoc
					        (
						        CampaignCode
						        , FilePath
						        , CreateDTime
						        , CreateBy
						        , LogLUDTime
						        , LogLUBy
					        )
					        select 
						        t.CampaignCode
						        , t.FilePath
						        , t.CreateDTime
						        , t.CreateBy
						        , t.LogLUDTime
						        , t.LogLUBy
					        from #input_Aud_CampaignDoc t --//[mylock]
					        ;
				        ");
					////
					string zzzzClauseInsert_Aud_CampaignDBDtl_zSave = CmUtils.StringUtils.Replace(@"
					        ---- Aud_CampaignDBDtl:
					        insert into Aud_CampaignDBDtl
					        (
						        CampaignCode
						        , DBCode
						        , CampaignDBStatusDtl
						        , LogLUDTime
						        , LogLUBy
					        )
					        select 
						        t.CampaignCode
						        , t.DBCode
						        , t.CampaignDBStatusDtl 
						        , t.LogLUDTime
						        , t.LogLUBy
					        from #input_Aud_CampaignDBDtl t --//[mylock]
					        ;
				        ");
					////
					string zzzzClauseInsert_Aud_CampaignDBPOSMDtl_zSave = CmUtils.StringUtils.Replace(@"
					        ---- Aud_CampaignDBPOSMDtl:
					        insert into Aud_CampaignDBPOSMDtl
					        (
						        CampaignCode
						        , DBCode
						        , POSMCode
						        , QtyDeliver
						        , QtyRetrieve
						        , DateDBRetrieve
						        , FlagActive
						        , LogLUDTime
						        , LogLUBy
					        )
					        select 
						        t.CampaignCode
						        , t.DBCode
						        , t.POSMCode
						        , t.QtyDeliver 
						        , t.QtyRetrieve 
						        , t.DateDBRetrieve 
						        , t.FlagActive 
						        , t.LogLUDTime
						        , t.LogLUBy
					        from #input_Aud_CampaignDBPOSMDtl t --//[mylock]
					        ;
				        ");
					////
					string strSqlExec = CmUtils.StringUtils.Replace(@"
					        ----
					        zzzzClauseInsert_Aud_Campaign_zSave
					        ----
					        zzzzClauseInsert_Aud_CampaignDoc_zSave
					        ----
							zzzzClauseInsert_Aud_CampaignDBDtl_zSave
							----
							zzzzClauseInsert_Aud_CampaignDBPOSMDtl_zSave
							----
				        "
						, "zzzzClauseInsert_Aud_Campaign_zSave", zzzzClauseInsert_Aud_Campaign_zSave
						, "zzzzClauseInsert_Aud_CampaignDoc_zSave", zzzzClauseInsert_Aud_CampaignDoc_zSave
						, "zzzzClauseInsert_Aud_CampaignDBDtl_zSave", zzzzClauseInsert_Aud_CampaignDBDtl_zSave
						, "zzzzClauseInsert_Aud_CampaignDBPOSMDtl_zSave", zzzzClauseInsert_Aud_CampaignDBPOSMDtl_zSave
						);
					////
					if (bMyDebugSql)
					{
						alParamsCoupleError.AddRange(new object[]{
							"Check.strSqlExec", strSqlExec
							});
					}
					DataSet dsExec = _cf.db.ExecQuery(strSqlExec);
				}
			#endregion

			// Return Good:
			MyCodeLabel_Done:
				TDALUtils.DBUtils.CommitSafety(_cf.db);
				mdsFinal.AcceptChanges();
				return mdsFinal;
			}
			catch (Exception exc)
			{
				#region // Catch of try:
				// Rollback:
				TDALUtils.DBUtils.RollbackSafety(_cf.db);

				// Return Bad:
				//alParamsCoupleError.AddRange(alPCErrEx);
				return TUtils.CProcessExc.Process(
					ref mdsFinal
					, exc
					, strErrorCodeDefault
					, alParamsCoupleError.ToArray()
					);
				#endregion
			}
			finally
			{
				#region // Finally of try:
				// Rollback and Release resources:
				TDALUtils.DBUtils.RollbackSafety(_cf.db);
				TDALUtils.DBUtils.ReleaseAllSemaphore(_cf.db_Sys, true);

				// Write ReturnLog:
				_cf.ProcessBizReturn(
					ref mdsFinal // mdsFinal
					, strTid // strTid
					, strFunctionName // strFunctionName
					);
				#endregion
			}
		}
		#endregion

		public DataSet Aud_Campaign_Approve(
			string strTid
			, DataRow drSession
			/////
			, object objCampaignCode
			, object objRemark
			)
		{
			#region // Temp:
			DataSet mdsFinal = CmUtils.CMyDataSet.NewMyDataSet(strTid);
			//int nTidSeq = 0;
			DateTime dtimeSys = DateTime.Now;
			string strFunctionName = "Aud_Campaign_Approve";
			string strErrorCodeDefault = TError.ErrDemoLab.Aud_Campaign_Approve;
			ArrayList alParamsCoupleError = new ArrayList(new object[]{
					"strFunctionName", strFunctionName
					, "dtimeSys", dtimeSys.ToString("yyyy-MM-dd HH:mm:ss")
					////
					, "objCampaignCode", objCampaignCode
					, "objRemark", objRemark
					});
			#endregion

			try
			{
				#region // Init:
				_cf.db.LogUserId = _cf.sinf.strUserCode;
				_cf.db.BeginTransaction();

				// Write RequestLog:
				_cf.ProcessBizReq(
					strTid // strTid
					, strFunctionName // strFunctionName
					, alParamsCoupleError // alParamsCoupleError
					);

				// Check Access/Deny:
				Sys_Access_CheckDeny(
					ref alParamsCoupleError
					, strFunctionName
					);
				#endregion

				#region // Refine and Check Input:
				////
				string strCampaignCode = TUtils.CUtils.StdParam(objCampaignCode);
				string strRemark = string.Format("{0}", objRemark).Trim();
				////
				DataTable dtDB_Aud_Campaign = null;
				{
					////
					Aud_Campaign_CheckDB(
						 ref alParamsCoupleError // alParamsCoupleError
						 , strCampaignCode // objCampaignCode
						 , TConst.Flag.Yes // strFlagExistToCheck
						 , TConst.CampaignStatus.Approve1 // strStatusListToCheck
						 , out dtDB_Aud_Campaign // dtDB_Aud_Campaign
						);
					////
					string strSqlCheck_Aud_CampaignDBDtl = CmUtils.StringUtils.Replace(@"
							select top 1
								t.*
							from Aud_CampaignDBDtl t --//[mylock]
							where (1=1)
								and t.CampaignCode = '@strCampaignCode'
							;
						"
						, "@strCampaignCode", strCampaignCode
						);

					DataTable dtDB_Check_Aud_CampaignDBDtl = _cf.db.ExecQuery(strSqlCheck_Aud_CampaignDBDtl).Tables[0];
					////
					if (dtDB_Check_Aud_CampaignDBDtl.Rows.Count < 1)
					{
						alParamsCoupleError.AddRange(new object[]{
							"Check.strCampaignCode", strCampaignCode
							});
						throw CmUtils.CMyException.Raise(
							TError.ErrDemoLab.Aud_Campaign_Approve_CampaignDBDtlNotFound
							, null
							, alParamsCoupleError.ToArray()
							);
					}
				}
				#endregion

				#region //// SaveTemp Aud_Campaign:
				{
					////
					TUtils.CUtils.MyBuildDBDT_Common(
						_cf.db
						, "#input_Aud_Campaign"
						, TConst.BizMix.Default_DBColType // strDefaultType
						, new object[]{
							"CampaignCode"
							, "Appr1DTime"
							, "Appr1By"
							, "CampaignStatus"
							, "Remark"
							, "LogLUDTime"
							, "LogLUBy"
							}
						, new object[]{
							new object[]{
								strCampaignCode, // CampaignCode
								dtimeSys.ToString("yyyy-MM-dd HH:mm:ss"), // Appr1DTime
								_cf.sinf.strUserCode, // Appr1By
								TConst.CampaignStatus.Approve1, // CampaignStatus
								strRemark, // Remark
								dtimeSys.ToString("yyyy-MM-dd HH:mm:ss"), // LogLUDTime
								_cf.sinf.strUserCode, // LogLUBy
								}
							}
						);
				}
				#endregion

				#region // SaveDB:
				{
					////
					string zzB_Update_Aud_Campaign_ClauseSet_zzE = @"
								t.LogLUDTime = f.LogLUDTime
								, t.LogLUBy = f.LogLUBy
								, t.Appr1DTime = f.Appr1DTime
								, t.Appr1By = f.Appr1By
								, t.CampaignStatus = f.CampaignStatus
								, t.Remark = f.Remark
								";
					////
					string zzB_Update_Aud_CampaignDBDtl_ClauseSet_zzE = @"
								t.LogLUDTime = f.LogLUDTime
								, t.LogLUBy = f.LogLUBy
								, t.CampaignDBStatusDtl = f.CampaignStatus
								";
					////
					string zzB_Update_Aud_Campaign_zzE = CmUtils.StringUtils.Replace(@"
							---- Aud_Campaign:
							update t
							set 
								zzB_Update_Aud_Campaign_ClauseSet_zzE
							from Aud_Campaign t --//[mylock]
								inner join #input_Aud_Campaign f --//[mylock]
									on t.IF_AcsInNo = f.IF_AcsInNo
							where (1=1)
							;
						"
						, "zzB_Update_Aud_Campaign_ClauseSet_zzE", zzB_Update_Aud_Campaign_ClauseSet_zzE
						);
					////
					string zzB_Update_Aud_CampaignDBDtl_zzE = CmUtils.StringUtils.Replace(@"
							update t
							set 
								zzB_Update_Aud_CampaignDBDtl_ClauseSet_zzE
							from Aud_CampaignDBDtl t --//[mylock]
								inner join #input_Aud_Campaign f --//[mylock]
									on t.IF_AcsInNo = f.IF_AcsInNo
							where (1=1)
							;
						"
						, "zzB_Update_Aud_CampaignDBDtl_ClauseSet_zzE", zzB_Update_Aud_CampaignDBDtl_ClauseSet_zzE
						);
					////
					string strSql_SaveOnDB = CmUtils.StringUtils.Replace(@"
							----
							zzB_Update_Aud_Campaign_zzE
							----
							zzB_Update_Aud_CampaignDBDtl_zzE
							----
						"
						, "zzB_Update_Aud_Campaign_zzE", zzB_Update_Aud_Campaign_zzE
						, "zzB_Update_Aud_CampaignDBDtl_zzE", zzB_Update_Aud_CampaignDBDtl_zzE
						);

					DataSet dsDB_Check = _cf.db.ExecQuery(
						strSql_SaveOnDB
						);
				}
				#endregion

				// Return Good:
				TDALUtils.DBUtils.CommitSafety(_cf.db);
				mdsFinal.AcceptChanges();
				return mdsFinal;
			}
			catch (Exception exc)
			{
				#region // Catch of try:
				// Rollback:
				TDALUtils.DBUtils.RollbackSafety(_cf.db);

				// Return Bad:
				return TUtils.CProcessExc.Process(
					ref mdsFinal
					, exc
					, strErrorCodeDefault
					, alParamsCoupleError.ToArray()
					);
				#endregion
			}
			finally
			{
				#region // Finally of try:
				// Rollback and Release resources:
				TDALUtils.DBUtils.RollbackSafety(_cf.db);
				TDALUtils.DBUtils.ReleaseAllSemaphore(_cf.db_Sys, true);

				// Write ReturnLog:
				_cf.ProcessBizReturn(
					ref mdsFinal // mdsFinal
					, strTid // strTid
					, strFunctionName // strFunctionName
					);
				#endregion
			}
		}
	}
}
