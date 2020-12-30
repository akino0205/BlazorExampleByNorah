using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlazorExampleByNorah.Models
{
    /// <summary>
    /// 로그인에 필요한 위즈도메인 사용자 정보
    /// </summary>
    public class WisdomainLoginForm
    {
        /// <summary>
        /// 이용할 사이트
        /// </summary>
        [Required]
        public string SiteName { get; set; }
        /// <summary>
        /// 사용자 ID
        /// </summary>
        [Required]
        public string UserId { get; set; }
        /// <summary>
        /// 사용자 비밀번호
        /// </summary>
        [Required]
        public string Password { get; set; }
    }

    /// <summary>
	/// 위즈도메인 사용자가 이용중인 사이트
	/// </summary>
	[JsonConverter(typeof(StringEnumConverter))]
    public enum WisdomainSitename
    {
        /// <summary>
        /// 영문 서비스
        /// </summary>
        SVCAP_SITE1,
        /// <summary>
        /// 한글 서비스
        /// </summary>
        SVCWD_SITE1,
        /// <summary>
        /// 일문 서비스
        /// </summary>
        SVCUL_SITE1
    }

	/// <summary>
	/// JWT 인증에 사용되는 토큰
	/// </summary>
	public class TokenSet
	{
		internal static readonly CookieOptions JWTCookieOptions = new CookieOptions
		{
			HttpOnly = true,
			//Secure = true,
			Expires = DateTimeOffset.Now.AddDays(7)
		};
		/// <summary>
		/// 인증을 위한 토큰
		/// </summary>
		[Required]
		public string AccessToken { get; set; }
		/// <summary>
		/// 재발급에 필요한 토큰
		/// </summary>
		[Required]
		public string RefreshToken { get; set; }

		/// <summary>
		/// 토큰을 쿠키에 저장하고 클레임정보를 생성한다
		/// </summary>
		/// <param name="scheme"></param>
		/// <param name="accessTokenCookie"></param>
		/// <param name="refreshTokenCookie"></param>
		/// <param name="context"></param>
		/// <returns></returns>
		public ClaimsPrincipal GenerateIdentity(string scheme, string accessTokenCookie, string refreshTokenCookie, HttpContext context)
		{
			context.Response.Cookies.Append(accessTokenCookie, AccessToken, JWTCookieOptions);
			context.Response.Cookies.Append(refreshTokenCookie, RefreshToken, JWTCookieOptions);
			var handler = new JwtSecurityTokenHandler();
			var jwtToken = handler.ReadToken(AccessToken) as JwtSecurityToken;
			return new ClaimsPrincipal(new ClaimsIdentity(jwtToken.Claims, scheme));
		}
	}
}
