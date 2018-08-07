using System;

namespace WebClient.Models
{
    [FlagsAttribute]
    public enum Authorization
    {
        Administrator = 0,
        Guest = 1
    }
}