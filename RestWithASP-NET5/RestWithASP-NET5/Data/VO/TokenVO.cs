namespace RestWithASP_NET5.Data.VO
{
    public class TokenVO
    {
        public TokenVO(bool authenticated, string created, string expiraton, string accessToken, string refreshToken)
        {
            Authenticated = authenticated;
            Created = created;
            Expiraton = expiraton;
            AccessToekn = accessToken;
            RefreshToken = refreshToken;
        }

        public bool Authenticated { get; set; }

        public string Created { get; set; }

        public string Expiraton { get; set; }

        public string AccessToekn { get; set; }

        public string RefreshToken { get; set; }
    }
}
