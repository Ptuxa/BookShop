namespace BookShop.Api.Models.dto.response
{
    public record BookResponse(Guid Id,
        string title,
        string description,
        int price
        ); 
}
