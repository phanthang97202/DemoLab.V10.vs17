﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Lab.Utils
{
	public class ErrorCodes
	{
		public static Dictionary<string, string> DIC_ERROR_CODES = new Dictionary<string, string>()
		{
			
		{ "ErrDemo.Lab.", "Lỗi Demo.Lab" },
        { "ErrDemo.Lab.Mst_AreaMarket_CheckDB_AMCodeNotFound", "Không tìm thấy vùng thị trường" },
        {"ErrDemo.Lab.Mst_AreaMarket_CheckDB_AMCodeExis","Vùng thị trường đã tồn tại"},
        {"ErrDemo.Lab.Mst_AreaMarket_CheckDB_FlagActiveNotMatched","Vùng thị trường không hoạt động"},
        {"ErrDemo.Lab.Mst_AreaMarket_CheckDB_FlagRootNotMatched","Vùng thị trường gốc không hoạt động"},
        {"ErrDemo.Lab.Mst_AreaMarket_Get","Không tạo được vùng thị trường"},
        {"ErrDemo.Lab.Mst_AreaMarket_Create","Không tạo được vùng thị trường"},
        {"ErrDemo.Lab.Mst_AreaMarket_Create_InvalidAMCode","Mã vùng thị trường không hợp lệ"},
        {"ErrDemo.Lab.Mst_AreaMarket_Create_InvalidAMCodeParent","Mã vùng thị trường gốc không hợp lệ"},
        {"ErrDemo.Lab.Mst_AreaMarket_Create_InvalidAMName","Tên vùng thị trường không hợp lệ"},
        {"ErrDemo.Lab.Mst_AreaMarket_Update","Không cập nhật được vùng thị trường"},
        {"ErrDemo.Lab.Mst_AreaMarket_Update_InvalidAMCode","Mã vùng thị trường không hợp lệ"},
        {"ErrDemo.Lab.Mst_AreaMarket_Update_InvalidAMCodeParent","Mã vùng thị trường gốc không hợp lệ"},
        {"ErrDemo.Lab.Mst_AreaMarket_Update_InvalidAMName","Tên vùng thị trường không hợp lệ"},
        {"ErrDemo.Lab.Mst_AreaMarket_Delete","Không xóa được vùng thị trường"},
        {"ErrDemo.Lab.Mst_Dealer_CheckDB_DLCodeExist","Đại lý đã tồn tại"},
        {"ErrDemo.Lab.Mst_Dealer_CheckDB_FlagActiveNotMatched","Đại lý không hoạt động"},
        {"ErrDemo.Lab.Mst_Dealer_CheckDB_FlagRootNotMatched","Đại lý gốc không hoạt động"},
        {"ErrDemo.Lab.Mst_Dealer_Get","Không có Đại lý" },
        {"ErrDemo.Lab.Mst_Dealer_Get_01","Không có Đại lý"},
        {"ErrDemo.Lab.Mst_Dealer_Create","Không tạo được Đại lý"},
        {"ErrDemo.Lab.Mst_Dealer_Create_InvalidDLCode","Mã Đại lý không hợp lệ"},
        {"ErrDemo.Lab.Mst_Dealer_Create_InvalidDLCodeParent","Mã Đại lý gốc không hợp lệ"},
        {"ErrDemo.Lab.Mst_Dealer_Create_InvalidDLName","Tên Đại lý không hợp lệ"},
        {"ErrDemo.Lab.Mst_Dealer_Update","Không cập nhật được Đại lý"},
        {"ErrDemo.Lab.Mst_Dealer_Update_InvalidDLCode","Mã Đại lý không hợp lệ"},
        {"ErrDemo.Lab.Mst_Dealer_Update_InvalidDLCodeParent","Mã Đại lý gốc không hợp lệ"},
        {"ErrDemo.Lab.Mst_Dealer_Update_InvalidDLName","Tên Đại lý không hợp lệ"},
        {"ErrDemo.Lab.Mst_Dealer_Delete","Không xóa được đại lý"},
        {"ErrDemo.Lab.Mst_Channel_CheckDB_ChannelCodeNotFound","Không tìm thấy kênh bán hàng"},
        {"ErrDemo.Lab.Mst_Channel_CheckDB_ChannelCodeExist","Kênh bán hàng đã tồn tại"},
        {"ErrDemo.Lab.Mst_Channel_CheckDB_FlagActiveNotMatched","Kênh bán hàng không hoạt động"},
        {"ErrDemo.Lab.Mst_Channel_Get","Không có kênh bán hàng"},
        {"ErrDemo.Lab.Mst_Channel_Create","Không tạo được kênh bán hàng"},
        {"ErrDemo.Lab.Mst_Channel_Create_InvalidChannelCode","Mã kênh bán hàng không hợp lệ"},
        {"ErrDemo.Lab.Mst_Channel_Create_InvalidChannelName","Tên kênh bán hàng không hợp lệ"},
        {"ErrDemo.Lab.Mst_Channel_Update","Không cập nhật được kênh bán hàng"},
        {"ErrDemo.Lab.Mst_Channel_Update_InvalidChannelCode","Mã kênh bán hàng không hợp lệ"},
        {"ErrDemo.Lab.Mst_Channel_Update_InvalidChannelName","Tên kênh bán hàng không hợp lệ"},
        {"ErrDemo.Lab.Mst_Channel_Delete","Không xóa được kênh bán hàng"},
        {"ErrDemo.Lab.Mst_ChannelDealer_Save","Không lưu được đại lý vào kênh bán hàng"},
        {"ErrDemo.Lab.Mst_ChannelDealer_Add","Không thêm được đại lý vào kênh bán hàng"},
        {"ErrDemo.Lab.Mst_ChannelDealer_Del","Không xóa được đại lý ra khỏi kênh bán hàng"},
        {"ErrDemo.Lab.Mst_ChannelDealer_Del_ChannelDealerNotFound","Không tìm thấy đại lý được gán vào kênh bán hàng"},
        {"ErrDemo.Lab.Mst_CalendarType_CheckDB_CalendarTypeNotFound","Không tìm thấy lịch trình công việc"},
        {"ErrDemo.Lab.Mst_CalendarType_CheckDB_CalendarTypeExist","Lịch trình không tồn tại"},
        {"ErrDemo.Lab.Mst_CalendarType_CheckDB_FlagActiveNotMatched","Lịch trình không hoạt động"},
        {"ErrDemo.Lab.Mst_Calendar_CheckDB_DateNotFound","Không tìm thấy ngày trong lịch trình công việc"},
        {"ErrDemo.Lab.Mst_Calendar_CheckDB_DateExist","Ngày làm việc đã tồn tại"},
        {"ErrDemo.Lab.Mst_Calendar_CheckDB_DateStatusNotMatched","Trạng thái ngày làm việc không hoạt động"},
        {"ErrDemo.Lab.Mst_Calendar_Get","Không tạo được lịch trình công việc"},
        {"ErrDemo.Lab.Mst_Calendar_GetDayOfMonth","Không tạo được ngày của tháng trong lịch trình công việc"},
        {"ErrDemo.Lab.Mst_Calendar_ResetYear_InvalidYear","Năm không hợp lệ"},
        {"ErrDemo.Lab.Mst_Calendar_ResetYear_InvalidCalendarType","Loại lịch trình không hợp lệ"},
        {"ErrDemo.Lab.Mst_Calendar_UpdateDateStatus","Trạng thái ngày làm việc đã được cập nhật"},
        {"ErrDemo.Lab.Mst_Calendar_UpdateDateStatus_InvalidCalendarType","Loại lịch trình không hợp lệ"},
        {"ErrDemo.Lab.Mst_Calendar_UpdateDateStatus_InvalidDate","Ngày làm việc không hợp lệ"},
        {"ErrDemo.Lab.Mst_ProductGroup_CheckDB_PrdGrpCodeNotFound","Không tìm thấy mã nhóm sản phẩm"},
        {"ErrDemo.Lab.Mst_ProductGroup_CheckDB_PrdGrpCodeExist","Mã nhóm sản phẩm đã tồn tại"},
        {"ErrDemo.Lab.Mst_ProductGroup_CheckDB_FlagActiveNotMatched","Nhóm sản phẩm không hoạt động"},
        {"ErrDemo.Lab.Mst_ProductGroup_CheckDB_FlagRootNotMatched","Nhóm sản phẩm gốc không hoạt động"},
        {"ErrDemo.Lab.Mst_ProductGroup_Get","Không tạo được nhóm sản phẩm"},
        {"ErrDemo.Lab.Mst_ProductGroup_Create","Không tạo được nhóm sản phẩm"},
        {"ErrDemo.Lab.Mst_ProductGroup_Create_InvalidPrdGrpCode","Mã nhóm sản phẩm không hợp lệ"},
        {"ErrDemo.Lab.Mst_ProductGroup_Create_InvalidPrdGrpCodeParent","Mã nhóm sản phẩm gốc không hợp lệ"},
        {"ErrDemo.Lab.Mst_ProductGroup_Create_InvalidPrdGrpName","Tên nhóm sản phẩm không hợp lệ"},
        {"ErrDemo.Lab.Mst_ProductGroup_Update","Không tạo được nhóm sản phẩm"},
        {"ErrDemo.Lab.Mst_ProductGroup_Update_InvalidPrdGrpCode","Mã nhóm sản phẩm không hợp lệ"},
        {"ErrDemo.Lab.Mst_ProductGroup_Update_InvalidPrdGrpCodeParent","Mã nhóm sản phẩm gốc không hợp lệ"},
        {"ErrDemo.Lab.Mst_ProductGroup_Update_InvalidPrdGrpName","Tên nhóm sản phẩm không hợp lệ"},
        {"ErrDemo.Lab.Mst_ProductGroup_Delete","Không xóa được nhóm sản phẩm"},
        {"ErrDemo.Lab.Mst_Product_CheckDB_PrdCodeNotFound","Không tìm thấy mã sản phẩm"},
        {"ErrDemo.Lab.Mst_Product_CheckDB_PrdCodeExist","Mã sản phẩm đã tồn tại"},
        {"ErrDemo.Lab.Mst_Product_CheckDB_FlagActiveNotMatched","Sản phẩm không hoạt động"},
        {"ErrDemo.Lab.Mst_Product_Get","Không tạo được sản phẩm"},
        {"ErrDemo.Lab.Mst_Product_Create","Không tạo được sản phẩm"},
        {"ErrDemo.Lab.Mst_Product_Create_InvalidPrdCode","Mã sản phẩm không hợp lệ"},
        {"ErrDemo.Lab.Mst_Product_Create_InvalidPrdName","Tên sản phẩm không hợp lệ"},
        {"ErrDemo.Lab.Mst_Product_Update","Không tạo được sản phẩm"},
        {"ErrDemo.Lab.Mst_Product_Update_InvalidPrdCode","Mã sản phẩm không hợp lệ"},
        {"ErrDemo.Lab.Mst_Product_Update_InvalidPrdName","Tên sản phẩm không hợp lệ"},
        {"ErrDemo.Lab.Mst_Product_Delete","Không xóa được sản phẩm"},
        {"ErrDemo.Lab.Mst_PrdUnitDtl_Save","Không lưu được đơn vị sản phẩm"},
        {"ErrDemo.Lab.Mst_PrdUnitDtl_Save_InputTblDtlNotFound","Không tìm thấy đơn vị sản phẩm"},
        {"ErrDemo.Lab.Mst_SchInstType_CheckDB_SchInstTypeNotFound","Không tìm thấy loại hình ảnh trong cơ sở dữ liệu"},
        {"ErrDemo.Lab.Mst_SchInstType_CheckDB_SchInstTypeExist","Loại hình ảnh đã tồn tại trong cơ sở dữ liệu"},
        {"ErrDemo.Lab.Mst_SchInstType_CheckDB_FlagActiveNotMatched","Loại hình ảnh không hoạt động "},
        {"ErrDemo.Lab.Mst_SchInstType_Get","Không tạo được loại hình ảnh"},
        {"ErrDemo.Lab.Mst_PrdUnit_CheckDB_PrdUnitCodeNotFound","Không tìm thấy mã đơn vị sản phẩm trong cơ sở dữ liệu"},
        {"ErrDemo.Lab.Mst_PrdUnit_CheckDB_PrdUnitCodeExist","Mã đơn vị sản phẩm đã tồn tại"},
        {"ErrDemo.Lab.Mst_PrdUnit_CheckDB_FlagActiveNotMatched","Mã đơn vị sản phẩm không hoạt động"},
        {"ErrDemo.Lab.Mst_PrdUnit_Get","Không tạo được mã đơn vị sản phẩm"},
        {"ErrDemo.Lab.Mst_PrdUnit_Create","Không tạo được mã đơn vị sản phẩm"},
        {"ErrDemo.Lab.Mst_PrdUnit_Create_InvalidPrdUnitCode","Mã đơn vị sản phẩm không hợp lệ"},
        {"ErrDemo.Lab.Mst_PrdUnit_Create_InvalidPrdUnitName","Tên đơn vị sản phẩm không hợp lệ"},
        {"ErrDemo.Lab.Mst_PrdUnit_Update","Không tạo được đơn vị sản phẩm"},
        {"ErrDemo.Lab.Mst_PrdUnit_Update_InvalidPrdUnitCode","Mã đơn vị sản phẩm không hợp lệ"},
        {"ErrDemo.Lab.Mst_PrdUnit_Update_InvalidPrdUnitName","Tên đơn vị sản phẩm không hợp lệ"},
        {"ErrDemo.Lab.Mst_PrdUnit_Delete","Không xóa được đơn vị sản phẩm"},
        {"ErrDemo.Lab.Wk_Task_CheckDB_TaskCodeNotFound","Không tìm thấy mã công việc"},
        {"ErrDemo.Lab.Wk_Task_CheckDB_TaskCodeExist","Mã công việc đã tồn tại"},
        {"ErrDemo.Lab.Wk_Task_CheckDB_TaskStatusNotMatched","Trạng thái công việc không hoạt động"},
        {"ErrDemo.Lab.Wk_Task_Get","Không tạo được công việc"},
        {"ErrDemo.Lab.Wk_Task_Create","Không tạo được công việc"},
        {"ErrDemo.Lab.Wk_Task_Create_InvalidTaskCode","Mã công việc không hợp lệ"},
        {"ErrDemo.Lab.Wk_Task_Update","Không tạo được công việc"},
        {"ErrDemo.Lab.Wk_Task_Update_InvalidTaskCode","Mã công việc không hợp lệ"},
        {"ErrDemo.Lab.Wk_Task_Delete","Không xóa được công việc"},
        {"ErrDemo.Lab.Wk_UserSchedule_CheckDB_SchCodeNotFound","Không tìm thấy mã lịch trình công việc trong cơ sở dữ liệu"},
        {"ErrDemo.Lab.Wk_UserSchedule_CheckDB_SchCodeExist","Mã lịch trình công việc đã tồn tại"},
        {"ErrDemo.Lab.Wk_UserSchedule_CheckDB_USStatusNotMatched","Trạng thái của lịch trình công việc không hoạt động"},
        {"ErrDemo.Lab.Wk_UserSchedule_GetX","Không tạo được lịch trình công việc"},
        {"ErrDemo.Lab.Wk_UserSchedule_AddX","Không thêm được lịch trình công việc"},
        {"ErrDemo.Lab.Wk_Wk_UserSchedule_AddX_InvalidSchCode","Mã lịch trình công việc không hợp lệ"},
        {"ErrDemo.Lab.Wk_Wk_UserSchedule_AddX_InvalidUserCode","Mã người dùng không hợp lệ"},
        {"ErrDemo.Lab.Wk_UserSchedule_AddX_InvalidEffDTimeStart","Ngày bắt đầu không hợp lệ"},
        {"ErrDemo.Lab.Wk_UserSchedule_AddX_InvalidEffDTimeEnd","Ngày kết thúc không hợp lệ"},
        {"ErrDemo.Lab.Wk_UserSchedule_AddX_InvalidEffDTimeStartBeforeEffDTimeEnd","Ngày bắt đầu <= Ngày kết thúc"},
        {"ErrDemo.Lab.Wk_UserSchedule_AddX_InvalidEffDTimeStartAfterEffSysDate","Ngày bắt đầu <= Ngày kết thúc"},
        {"ErrDemo.Lab.Wk_UserSchedule_AddX_Input_Wk_UserScheduleDtlNotFound","Cần chọn ít nhất 1 đại lý khi tạo lịch trình công việc"},
        {"ErrDemo.Lab.Wk_UserSchedule_AddX_Input_Wk_UserScheduleExistConflictDealerDateInput","Lịch trình công việc đã tồn tại"},
        {"ErrDemo.Lab.Wk_UserSchedule_UpdateX_InvalidSchCode","Mã lịch trình công việc không hợp lệ"},
        {"ErrDemo.Lab.Wk_UserSchedule_UpdateX_InvalidEffDTimeStart","Ngày bắt đầu không hợp lệ"},
        {"ErrDemo.Lab.Wk_UserSchedule_UpdateX_InvalidEffDTimeEnd","Ngày kết thúc không hợp lệ"},
        {"ErrDemo.Lab.Wk_UserSchedule_UpdateX_InvalidEffDTimeStartBeforeEffDTimeEnd","Ngày bắt đầu <= Ngày kết thúc"},
        {"ErrDemo.Lab.Wk_UserSchedule_UpdateX_InvalidEffDTimeStartAfterEffSysDate","Ngày bắt đầu <= Ngày kết thúc"},
        {"ErrDemo.Lab.Wk_UserScheduleDtl_AddX_InvalidSchCode","Mã lịch trình công việc không hợp lệ"},
        {"ErrDemo.Lab.Wk_UserScheduleDtl_AddX_InvalidUserCode","Mã người dùng không hợp lệ"},
        {"ErrDemo.Lab.Wk_UserScheduleDtl_AddX_Input_Wk_UserScheduleExistConflictDealerDateInput","Lịch trình công việc đã tồn tại"},
        {"ErrDemo.Lab.Wk_UserScheduleDtl_UpdX_UserScheduleDtlNotFound","Cần chọn ít nhất 1 đại lý"},
        {"ErrDemo.Lab.Wk_UserScheduleDtl_DelX_UserScheduleDtlNotFound","Cần chọn ít nhất 1 đại lý"},
        {"ErrDemo.Lab.Wk_UserScheduleDtl_DelX_UserScheduleInstExist","Không được xóa đại lý đã thực hiện lịch trình"},
        {"ErrDemo.Lab.Wk_UserScheduleDtl_Approve_UserScheduleDtlNotFound","Cần chọn ít nhất 1 đại lý"},
        {"ErrDemo.Lab.Wk_UserScheduleDtl_Cancel_UserScheduleDtlNotFound","Cần chọn ít nhất 1 đại lý"},
        {"ErrDemo.Lab.Wk_UserScheduleInst_UpdX_Wk_UserScheduleInstNotFound","Không tìm thấy hình ảnh trong lịch trình"},
        {"ErrDemo.Lab.Wk_UserScheduleInst_SaveX_Wk_UserScheduleDtlNotFound","Không tìm thấy đại lý trong lịch trình"},
        {"ErrDemo.Lab.Wk_UserScheduleInst_SaveX_Wk_UserScheduleInstNotFound","Không tìm thấy hình ảnh trong lịch trình"},
        {"ErrDemo.Lab.Wk_UserScheduleInst_AddX_InvalidEffDTimeStartBeforeEffCreateTime","Ngày bắt đầu <= Ngày kết thúc"},
        {"ErrDemo.Lab.Wk_UserScheduleInst_SaveX_UserScheduleDtl_InvalidUSStatusDtl","Trạng thái đại lý của lịch trình công việc không hợp lệ"},
        {"ErrDemo.Lab.Aud_Campaign_CheckDB_CampaignCodeNotFound","Không tìm thấy mã chiến dịch"},
        {"ErrDemo.Lab.Aud_Campaign_CheckDB_CampaignCodeExist","Mã chiến dịch đã tồn tại"},
        {"ErrDemo.Lab.Aud_Campaign_CheckDB_CampaignStatusNotMatched","Trạng thái chiến dịch không hoạt động"},
        {"ErrDemo.Lab.Aud_Campaign_AddX_InvalidCampaignCode","Mã chiến dịch không hợp lệ"},
        {"ErrDemo.Lab.Aud_Campaign_AddX_InvalidCampaignName","Tên chiến dịch không hợp lệ"},
        {"ErrDemo.Lab.Aud_Campaign_AddX_InvalidEffDTimeStart","Ngày bắt đầu chiến dịch không hợp lệ"},
        {"ErrDemo.Lab.Aud_Campaign_AddX_InvalidEffDTimeEnd","Ngày kết thúc chiến dịch không hợp lệ"},
        {"ErrDemo.Lab.Aud_Campaign_AddX_InvalidEffDTimeStartBeforeEffDTimeEnd","Ngày bắt đầu <= Ngày kết thúc"},
        {"ErrDemo.Lab.Aud_Campaign_AddX_InvalidEffDTimeStartAfterEffSysDate","Ngày bắt đầu <= Ngày kết thúc"},
        {"ErrDemo.Lab.Aud_Campaign_AddX_Input_Aud_CampaignDtlNotFound","Không tìm thấy đại lý trong chiến dịch"},
        {"ErrDemo.Lab.Aud_Campaign_AddX_Input_Aud_CampaignDtlInvalid","Mã đại lý không hợp lệ"},
        {"ErrDemo.Lab.Aud_Campaign_UpdX_InvalidCampaignCode","Mã chiến dịch không hợp lệ"},
        {"ErrDemo.Lab.Aud_Campaign_UpdX_InvalidCampaignName","Tên chiến dịch không hợp lệ"},
        {"ErrDemo.Lab.Aud_Campaign_UpdX_InvalidEffDTimeStart","Ngày bắt đầu chiến dịch không hợp lệ"},
        {"ErrDemo.Lab.Aud_Campaign_UpdX_InvalidEffDTimeEnd","Ngày kết thúc chiến dịch không hợp lệ"},
        {"ErrDemo.Lab.Aud_Campaign_UpdX_InvalidEffDTimeStartBeforeEffDTimeEnd","Ngày bắt đầu <= Ngày kết thúc"},
        {"ErrDemo.Lab.Aud_Campaign_UpdX_InvalidEffDTimeStartAfterEffSysDate","Ngày bắt đầu <= Ngày kết thúc"},
        {"ErrDemo.Lab.Aud_Campaign_CheckStatus_InvalidCampaignStatus","Trạng thái chiến dịch không hợp lệ"},
        {"ErrDemo.Lab.Aud_Campaign_Cancel","Không hủy được chiến dịch"},
        {"ErrDemo.Lab.Aud_Campaign_Cancel_CampaignNotFound","Không tìm thấy chiến dịch"},
        {"ErrDemo.Lab.Wk_UserSchedule_Delete","Không xóa được lịch trình công việc"},
        //{"ErrDemo.Lab.Aud_Campaign_AddX_InvalidCampaignCode","Mã chiến dịch không hợp lệ"},
        {"ErrDemo.Lab.Aud_CampaignDtl_AddX_InvalidDLCode","Mã đại lý không hợp lệ"},
        {"ErrDemo.Lab.Aud_CampaignDtl_AddX_Aud_CampaignDtlExist","Đại lý đã tồn tại trong chiến dịch"},
        {"ErrDemo.Lab.Aud_CampaignDtl_CancelX_CampaignDtlNotFound","Không tìm thấy đại lý trong chiến dịch"},
        {"ErrDemo.Lab.Aud_CampaignDtl_DelX_CampaignDtlNotFound","Không tìm thấy đại lý trong chiến dịch"},
        {"ErrDemo.Lab.Aud_CampaignDtl_DelX_CampaignInstExist","Hình ảnh đã tồn tại trong chiến dịch"},
        {"ErrDemo.Lab.Aud_CampaignInst_CheckDB_CICodeNotFound","Không tìm thấy mã chiến dịch trong cơ sở dữ liệu"},
        {"ErrDemo.Lab.Aud_CampaignInst_CheckDB_CICodeExist","Mã chiến dịch đã tồn tại trong cơ sở dữ liệu"},
        {"ErrDemo.Lab.Aud_CampaignInst_CheckDB_CIStatusNotMatched","Trạng thái chiến dịch không hoạt động"},
        {"ErrDemo.Lab.Aud_CampaignInst_AddX_Aud_CampaignDtlNotFoundOrInvalid","Đại lý trong chiến dịch không tìm thấy hoặc không hợp lệ"},
        {"ErrDemo.Lab.Aud_CampaignInst_AddX_MinIntervalDaysInvalid","Khoảng thời gian không hợp lệ"},
        {"ErrDemo.Lab.Aud_CampaignInst_Approve_CampaignDtlNotFoundOrInvalid","Đại lý trong chiến dịch không tìm thấy hoặc không hợp lệ"},
        {"ErrDemo.Lab.Aud_CampaignInst_Approve_CampaignInstDtlNotFound","Không tìm thấy lần chụp ảnh của đại lý trong chiến dịch"},
        {"ErrDemo.Lab.Aud_CampaignInst_Cancel_CampaignDtlNotFoundOrInvalid","Đại lý trong chiến dịch không tìm thấy hoặc không hợp lệ"},
        {"ErrDemo.Lab.Aud_CampaignInstDtl_UpdX_CampaignInstDtlNotFound","Không tìm thấy lần chụp ảnh của đại lý trong chiến dịch"},
        {"ErrDemo.Lab.Aud_CampaignInstDtl_SaveX_CampaignDtlNotFoundOrInvalid","Đại lý trong chiến dịch không tìm thấy hoặc không hợp lệ"},
        {"ErrDemo.Lab.Aud_CampaignInstDtl_SaveX_CampaignInstDtlNotFound","Không tìm thấy lần chụp ảnh của đại lý trong chiến dịch"},
        {"ErrDemo.Lab.Ord_Order_CheckDB_OrdCodeNotFound","Không tìm thấy mã đơn hàng"},
        {"ErrDemo.Lab.Ord_Order_CheckDB_OrdCodeExist","Mã đơn hàng đã tồn tại"},
        {"ErrDemo.Lab.Ord_Order_CheckDB_OrdStatusNotMatched","Trạng thái đơn hàng không hoạt động"},
        {"ErrDemo.Lab.Ord_Order_GetX","Không tạo được đơn hàng"},
        {"ErrDemo.Lab.Ord_Order_SaveX","Không lưu được đơn hàng"},
        {"ErrDemo.Lab.Ord_Order_SaveX_InputOrderDtlNotFound","Không tìm thấy đơn hàng của đại lý"},
        {"ErrDemo.Lab.Ord_Order_SaveX_InvalidDtlQtyOrd","Số lượng sản phẩm không hợp lệ"},
        {"ErrDemo.Lab.Ord_Order_Approve_InputOrderDtlNotFound","Không tìm thấy đơn hàng của đại lý"},
        {"ErrDemo.Lab.Ord_Order_Approve_InvalidDtlQtyOrd","Số lượng sản phẩm không hợp lệ"},
        {"ErrDemo.Lab.Ord_Order_Cancel","Không hủy được đơn hàng"},
        {"ErrDemo.Lab.Rpt_UserSchedule_01","Báo cáo lịch trình nhân viên thị trường"},
        {"ErrDemo.Lab.Rpt_SalesSM_01","Báo cáo sản lượng nhân viên thị trường"},
        {"ErrDemo.Lab.Rpt_SalesDL_01","Báo cáo biến động sản lượng đặt hàng theo đại lý"},
        {"ErrDemo.Lab.Rpt_DensityAM_01","Báo cáo tỷ trọng sản lượng theo vùng thị trường"},
        {"ErrDemo.Lab.Rpt_DensityChannel_01","Báo cáo tỷ trọng sản lượng theo kênh phân phối"},
        // 20140213
        {"ErrDemo.Lab.Sys_Group_CheckDB_GroupCodeNotFound","Không tìm thấy mã nhóm trong cơ sở dữ liệu"},
		};

	}
}
