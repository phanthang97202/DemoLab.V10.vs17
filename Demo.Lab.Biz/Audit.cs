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
				string strCrtrScoreVerCode = string.Format("{0}", objCrtrScoreVerCode).Trim();
				string strCrtrScoreVerAUCode = string.Format("{0}", objCrtrScoreVerAUCode).Trim();
				string strCampaignName = string.Format("{0}", objCampaignName).Trim();
				string strEffDTimeStart = TUtils.CUtils.StdDTime(objEffDTimeStart);
				string strEffDTimeEnd = TUtils.CUtils.StdDTime(objEffDTimeEnd);
				int intQtyCheck = Convert.ToInt32(TUtils.CUtils.StdInt(objQtyCheck));
				int intQtySuccess = Convert.ToInt32(TUtils.CUtils.StdInt(objQtySuccess));
				int intMinIntervalDays = Convert.ToInt32(TUtils.CUtils.StdInt(objMinIntervalDays));
				int intReportEndDate = Convert.ToInt32(TUtils.CUtils.StdInt(objReportEndDate));
				TimeSpan subTimeStartEnd = (Convert.ToDateTime(strEffDTimeEnd)).Subtract(Convert.ToDateTime(strEffDTimeStart));
				string strMinImagesPerCheck = "1";
				string strMaxImagesPerCheck = "1000";
				string strAppr1DTime = null;
				string strAppr1By = null;
				string strAppr2DTime = null;
				string strAppr2By = null;
				string strFinishDTime = null;
				string strFinishBy = null;
				string strCancelDTime = null;
				string strCancelBy = null;
				string strCreateDTime = null;
				string strCreateBy = null;
				string strRemark = null;

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

						strCreateDTime = TUtils.CUtils.StdDTime(dtDB_Aud_Campaign.Rows[0]["CreateDTime"]);
						strCreateBy = TUtils.CUtils.StdParam(dtDB_Aud_Campaign.Rows[0]["CreateBy"]);
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
						, "" // strStatusListToCheck
						, out dtDB_Mst_CampainCriteria // dtDB_Mst_CampainCriteria
						);
					////
					if (strCrtrScoreVerCode == null || strCrtrScoreVerCode.Length < 1)
					{
						alParamsCoupleError.AddRange(new object[]{
							"Check.strCrtrScoreVerCode", strCrtrScoreVerCode
							});
						throw CmUtils.CMyException.Raise(
							TError.ErrDemoLab.Aud_Campaign_Save_InvalidCrtrScoreVerCode
							, null
							, alParamsCoupleError.ToArray()
							);
					}
					////
					if (strCrtrScoreVerAUCode == null || strCrtrScoreVerAUCode.Length < 1)
					{
						alParamsCoupleError.AddRange(new object[]{
							"Check.strCrtrScoreVerAUCode", strCrtrScoreVerAUCode
							});
						throw CmUtils.CMyException.Raise(
							TError.ErrDemoLab.Aud_Campaign_Save_InvalidCrtrScoreVerAUCode
							, null
							, alParamsCoupleError.ToArray()
							);
					}
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
					if (DateTime.Compare(Convert.ToDateTime(strEffDTimeEnd), Convert.ToDateTime(strEffDTimeStart)) < 0)
					{
						alParamsCoupleError.AddRange(new object[]{
							"Check.strEffDTimeEnd", strEffDTimeEnd
							});
						throw CmUtils.CMyException.Raise(
							TError.ErrDemoLab.Aud_Campaign_Save_EffDTimeEndSmallThanEffDTimeStart
							, null
							, alParamsCoupleError.ToArray()
							);
					}
					//// 
					if (intQtyCheck < 1)
					{
						alParamsCoupleError.AddRange(new object[]{
							"Check.QtyCheck", intQtyCheck
							});
						throw CmUtils.CMyException.Raise(
							TError.ErrDemoLab.Aud_Campaign_Save_InvalidQtyCheck
							, null
							, alParamsCoupleError.ToArray()
							);
					}
					//// 
					if (intQtySuccess < 1 || intQtySuccess > intQtyCheck)
					{
						alParamsCoupleError.AddRange(new object[]{
							"Check.QtySuccess", intQtySuccess
							});
						throw CmUtils.CMyException.Raise(
							TError.ErrDemoLab.Aud_Campaign_Save_InvalidQtySuccess
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
							"QtyCheck", TConst.BizMix.Default_DBColType,
							"QtySuccess", TConst.BizMix.Default_DBColType,
							"MinIntervalDays", TConst.BizMix.Default_DBColType,
							"MinImagesPerCheck", TConst.BizMix.Default_DBColType,
							"MaxImagesPerCheck", TConst.BizMix.Default_DBColType,
							"ReportEndDate", TConst.BizMix.Default_DBColType,
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
								strMinImagesPerCheck, // MinImagesPerCheck  
								strMaxImagesPerCheck, // MaxImagesPerCheck   
								intReportEndDate, // ReportEndDate   
								strAppr1DTime, // Appr1DTime
								strAppr1By, // Appr1By
								strAppr2DTime, // Appr2DTime
								strAppr2By, // Appr2By
								strFinishDTime, // FinishDTime
								strFinishBy, // FinishBy
								strCancelDTime, // CancelDTime
								strCancelBy, // CancelBy
								TConst.StatusUserScheduleDtl.Pending, // CampaignStatus   
								strRemark, // Remark
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

						////
						DataTable dtDB_Mst_CampainCriteria = null;

						Mst_CampainCriteria_CheckDB(
							ref alParamsCoupleError // alParamsCoupleError
							, strCampaignCode // objCampaignCode
							, TConst.Flag.Yes // strFlagExistToCheck
							, "" // strStatusListToCheck
							, out dtDB_Mst_CampainCriteria // dtDB_Mst_CampainCriteria
							);
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

				#region //// Refine and Check Aud_CampaignDBDtl:
				////
				DataTable dtInput_Aud_CampaignDBDtl = null;
				if (!bIsDelete)
				{
					////
					string strTableCheck = "Aud_CampaignDBDtl";
					////
					if (!dsData.Tables.Contains(strTableCheck))
					{
						alParamsCoupleError.AddRange(new object[]{
							"Check.TableName", strTableCheck
							});
						throw CmUtils.CMyException.Raise(
							TError.ErrDemoLab.Aud_CampaignDBDtl_Save_Input_CampaignDBDtlTblNotFound
							, null
							, alParamsCoupleError.ToArray()
							);
					}
					////
					dtInput_Aud_CampaignDBDtl = new DataTable(strTableCheck);
					dtInput_Aud_CampaignDBDtl.Columns.Add("DBCode");
					DataRow[] dtRow = dsData.Tables[strTableCheck].Select();
					ArrayList lst_Aud_CampaignDBDtl_Distinct = new ArrayList();

					for (int i = 0; i < dtRow.Length; i++)
					{
						string value = dtRow[i].ItemArray[0].ToString();

						if (!lst_Aud_CampaignDBDtl_Distinct.Contains(value))
						{
							lst_Aud_CampaignDBDtl_Distinct.Add(value);
						}
					}

					for (int i = 0; i < lst_Aud_CampaignDBDtl_Distinct.Count; i++)
					{
						dtInput_Aud_CampaignDBDtl.Rows.Add(lst_Aud_CampaignDBDtl_Distinct[i]);
					}
					////
					TUtils.CUtils.StdDataInTable(
						dtInput_Aud_CampaignDBDtl // dtData
						, "StdParam", "DBCode" // arrstrCouple   
						);
					////

					TUtils.CUtils.MyForceNewColumn(ref dtInput_Aud_CampaignDBDtl, "CampaignCode", typeof(object));
					TUtils.CUtils.MyForceNewColumn(ref dtInput_Aud_CampaignDBDtl, "CampaignDBStatusDtl", typeof(object));
					TUtils.CUtils.MyForceNewColumn(ref dtInput_Aud_CampaignDBDtl, "LogLUDTime", typeof(object));
					TUtils.CUtils.MyForceNewColumn(ref dtInput_Aud_CampaignDBDtl, "LogLUBy", typeof(object));
					////
					for (int nScan = 0; nScan < dtInput_Aud_CampaignDBDtl.Rows.Count; nScan++)
					{
						////
						DataRow drScan = dtInput_Aud_CampaignDBDtl.Rows[nScan];

						////
						DataTable dtDB_Mst_Distributor = null;

						Mst_Distributor_CheckDB(
							ref alParamsCoupleError // alParamsCoupleError
							, drScan["DBCode"] // drScan["DBCode"]
							, TConst.Flag.Yes // strFlagExistToCheck
							, "" // strStatusListToCheck
							, out dtDB_Mst_Distributor // dtDB_Mst_Distributor
							);
						////
						string strDBCode = string.Format("{0}", drScan["DBCode"]).Trim();
						if (strDBCode.Length < 1)
						{
							alParamsCoupleError.AddRange(new object[]{
							"Check.strDBCode", strDBCode
							});
							throw CmUtils.CMyException.Raise(
								TError.ErrDemoLab.Aud_CampaignDBDtl_Save_InvalidDBCode
								, null
								, alParamsCoupleError.ToArray()
								);
						}

						////
						drScan["CampaignCode"] = strCampaignCode;
						drScan["CampaignDBStatusDtl"] = TConst.Flag.Active;
						drScan["LogLUDTime"] = dtimeSys.ToString("yyyy-MM-dd HH:mm:ss");
						drScan["LogLUBy"] = _cf.sinf.strUserCode;
						////
					}
				}
				#endregion

				#region //// SaveTemp Aud_CampaignDBDtl:
				if (!bIsDelete)
				{
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

				#region //// Refine and Check Aud_CampaignDBPOSMDtl:
				////
				DataTable dtInput_Aud_CampaignDBPOSMDtl = null;
				if (!bIsDelete)
				{
					////
					string strTableCheck = "Aud_CampaignDBDtl";
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
						////
						string strQtyDeliver = string.Format("{0}", drScan["QtyDeliver"]).Trim();
						if (strQtyDeliver.Length < 1)
						{
							alParamsCoupleError.AddRange(new object[]{
							"Check.strQtyDeliver", strQtyDeliver
							});
							throw CmUtils.CMyException.Raise(
								TError.ErrDemoLab.Aud_CampaignDBPOSMDtl_Save_InvalidQtyDeliver
								, null
								, alParamsCoupleError.ToArray()
								);
						}

						////
						drScan["CampaignCode"] = strCampaignCode;
						drScan["QtyRetrieve"] = TConst.Flag.Inactive;
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
							"QtyDeliver", TConst.BizMix.Default_DBColType,
							"QtyRetrieve", TConst.BizMix.Default_DBColType,
							"DateDBRetrieve", TConst.BizMix.Default_DBColType,
							"FlagActive", TConst.BizMix.Default_DBColType,
							"LogLUDTime", TConst.BizMix.Default_DBColType,
							"LogLUBy", TConst.BizMix.Default_DBColType,
							}
						, dtInput_Aud_CampaignDBPOSMDtl
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
	}
}
