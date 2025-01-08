﻿using DSA_Examples.Utility;

namespace DSA_Examples
{
    abstract class Example
    {
        public Test<object?>[]? Tests { get; init; } // an array of Tests to be ran on the Example
    }
}
