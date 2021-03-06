﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FileFormats.PE.Tests
{
    public class Tests
    {
        [Fact]
        public void CheckIndexingInfo()
        {
            using (Stream s = File.OpenRead("TestBinaries/HelloWorld.exe"))
            {
                StreamAddressSpace fileContent = new StreamAddressSpace(s);
                PEFile pe = new PEFile(fileContent);
                Assert.Equal((uint)0x8000, pe.SizeOfImage);
                Assert.Equal((uint)0x577F5919, pe.Timestamp);
            }
        }
    }
}
