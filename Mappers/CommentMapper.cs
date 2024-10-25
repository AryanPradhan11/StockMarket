public static class CommentMapper {
    public static CommentDto commentDto (this Comment commentModel) {
        return new CommentDto {
            ID = commentModel.ID,
            Title = commentModel.Title,
            Content = commentModel.Content,
            CreatedOn = commentModel.CreatedOn,
            StockId = commentModel.StockId
        };
    }
}