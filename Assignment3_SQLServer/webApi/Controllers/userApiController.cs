﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;
using Entities;
using BAL;

namespace webApi.Controllers
{
    [EnableCors(origins: "https://localhost:44368", headers: "*", methods: "*")]

    public class userApiController : ApiController
    {
        [HttpGet]
        public Object validate(String login,String pass)
        {
            if (BAL.BO.loginUser(login,pass) == true)
            {
                string key = "my_secret_key_12345";
                var issuer = "http://mysite.com";
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var permClaims = new List<Claim>();
                permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                permClaims.Add(new Claim("valid", "1"));
                permClaims.Add(new Claim("userid", "1"));
                permClaims.Add(new Claim("name", "bilal"));

                var token = new JwtSecurityToken(issuer,
                                issuer,
                                permClaims,
                                expires: DateTime.Now.AddDays(1),
                                signingCredentials: credentials);
                var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
                
                return new { data = jwt_token };
            }
            else
                return new { data = "Invalid" };
        }
        [HttpGet]
        public Object newUser(String name,String login, String pass)
        {
            if (BAL.BO.loginValidationForNew(login) == false)
            {
                BAL.BO.insertUser(name, login, pass);
                string key = "my_secret_key_12345";
                var issuer = "http://mysite.com";
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var permClaims = new List<Claim>();
                permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                permClaims.Add(new Claim("valid", "1"));
                permClaims.Add(new Claim("userid", "1"));
                permClaims.Add(new Claim("name", "bilal"));

                var token = new JwtSecurityToken(issuer,
                                issuer,
                                permClaims,
                                expires: DateTime.Now.AddDays(1),
                                signingCredentials: credentials);
                var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);

                return new { data = jwt_token };
            }
            else
                return new { data = "Invalid" };
        }
        [HttpGet]
        public int sum(std std)
        {
            return std.temp;
        }
        [HttpGet]
        public int test()
        {
            return 1;
        }
    }
    public class std
    {
        public int temp { get; set; }
    }
}