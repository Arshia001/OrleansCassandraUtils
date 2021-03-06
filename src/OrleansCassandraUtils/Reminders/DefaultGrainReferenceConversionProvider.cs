﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orleans.Runtime;

namespace OrleansCassandraUtils.Reminders
{
    class DefaultGrainReferenceConversionProvider : IGrainReferenceConversionProvider
    {
        IGrainReferenceConverter grainReferenceConverter;

        public DefaultGrainReferenceConversionProvider(IGrainReferenceConverter grainReferenceConverter)
        {
            this.grainReferenceConverter = grainReferenceConverter;
        }

        public GrainReference GetGrain(byte[] key)
        {
            return grainReferenceConverter.GetGrainFromKeyString(Encoding.UTF8.GetString(key));
        }

        public byte[] GetKey(GrainReference grainRef)
        {
            return Encoding.UTF8.GetBytes(grainRef.ToKeyString());
        }
    }
}