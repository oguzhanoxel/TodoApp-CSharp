namespace Domain.Dtos.Todo.ResponseDtos;

public class TodoResponseDto
{
    public int Id { get; set; }
    public string Title { get; set; }
	public string Description { get; set; }
	public DateTime StartDate { get; set; }
	public DateTime EndDate { get; set; }
	public bool IsDone { get; set; } = false;
	public int CategoryId { get; set; }
	public string UserId { get; set; }
	public DateTime CreatedTime { get; set; }
	public DateTime UpdatedTime { get; set; }
}
