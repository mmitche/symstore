﻿using System;
using System.Collections.Generic;
using System.Linq;
// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.
using System.Threading.Tasks;
using Xunit;

namespace FileFormats.Tests
{
    public class AddressSpace
    {
        [Fact]
        public void GoodReads()
        {
            MemoryBufferAddressSpace buffer = new MemoryBufferAddressSpace(new byte[] { 1, 2, 3, 4, 5 });
            Assert.True(Enumerable.SequenceEqual(new byte[] { 1 }, buffer.Read(0, 1)));
            Assert.True(Enumerable.SequenceEqual(new byte[] { 3, 4 }, buffer.Read(2, 2)));
            Assert.True(Enumerable.SequenceEqual(new byte[] { 1, 2, 3, 4, 5 }, buffer.Read(0, 5)));
            Assert.True(Enumerable.SequenceEqual(new byte[0], buffer.Read(0, 0)));
            Assert.True(Enumerable.SequenceEqual(new byte[0], buffer.Read(4, 0)));
        }

        [Fact]
        public void BadReads()
        {
            MemoryBufferAddressSpace buffer = new MemoryBufferAddressSpace(new byte[] { 1, 2, 3, 4, 5 });
            Assert.Throws<BadInputFormatException>(() =>
            {
                buffer.Read(5, 1);
            });
            Assert.Throws<BadInputFormatException>(() =>
            {
                buffer.Read(5, 0);
            });
            Assert.Throws<BadInputFormatException>(() =>
            {
                buffer.Read(3, 3);
            });
        }
    }
}
