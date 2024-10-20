namespace BookShop.Api.Models.dto.request
{
    public record BookRequest(string title, 
        string description,
        int price
        );      
}
