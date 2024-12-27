using System;
using System.Collections.Generic;

namespace Application.Wrappers
{
	public class ApiResponse<T>
	{
		public ApiResponse()
		{

		}

		// Constructor cho phản hồi thành công
		public ApiResponse(T data, string message = null)
		{
			Succeeded = true;
			Message = message;
			Data = data;
		}

		// Constructor cho phản hồi thất bại
		public ApiResponse(string message)
		{
			Succeeded = false;
			Message = message;
		}

		public bool Succeeded { get; set; } // Biểu thị thành công hay thất bại của hoạt động
		public string Message { get; set; } // Thông điệp đi kèm với phản hồi
		public List<string> Errors { get; set; } // Danh sách các lỗi (nếu có)
		public T Data { get; set; } // Dữ liệu kết quả của phản hồi
	}
}
