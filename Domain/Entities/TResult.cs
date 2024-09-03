namespace Domain.Entities;

public class TResult<T>
{
    public T Data { get; set; } //Chứa kiểu dữ liệu trả về của response
    public bool Success { get; set; } //Trạng thái
    public List<string> Errors { get; set; } //Danh sách lỗi



    #region Cái này kệ nó nha, không cần quan tâm
        // 
        // public static TResult<T> Failure(List<string> errors)
        // {
        //     return new TResult<T> { Success = false, Errors = errors };
        // }
    
        // public static TResult<T> SuccessResult(T data)
        // {
        //     return new TResult<T> { Success = true, Data = data };
        // }
    #endregion
}
