﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs;

// Static Factory Methodes
public class CustomResponseDto<T>
{
    public T Data { get; set; }
    [JsonIgnore]
    public List<String> Errors { get; set; }
    public int StatusCode { get; set; }
    public static CustomResponseDto<T> Success(int statusCode, T data) { 
        return new CustomResponseDto<T> { StatusCode = statusCode, Data = data, Errors = null};
    }
    public static CustomResponseDto<T> Success(int statusCode)
    {
        return new CustomResponseDto<T> { StatusCode = statusCode};
    }
    public static CustomResponseDto<T> Fail (int statusCode, List<string> Errors)
    {
        return new CustomResponseDto<T> { StatusCode = statusCode , Errors = Errors };
    }
    public static CustomResponseDto<T> Fail(int statusCode, string Errors)
    {
        return new CustomResponseDto<T> { StatusCode = statusCode, Errors = new List<string> { Errors } };
    }
}
