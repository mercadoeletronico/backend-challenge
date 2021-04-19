namespace MercadoEletronico.Challenge.Util
{
    public enum ResultStatus
    {
        Success = 200,
        Created = 201,
        NoContent = 204,
        BadRequest = 400,
        Unauthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        Conflict = 409,
        InternalError = 500
    }
}
