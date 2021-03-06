﻿using Capgemini.DataMigration.Core.Model;
using Capgemini.DataScrambler;
using Capgemini.DataScrambler.Scramblers;
using Capgemini.Xrm.DataMigration.Core;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.Xrm.DataMigration.Engine.Obfuscate
{
    public class CrmObfuscateIntHandler : ICrmObfuscateHandler
    {
        private ScramblerClient<int> intScramblerClient;

        public CrmObfuscateIntHandler()
        {
            this.intScramblerClient = new ScramblerClient<int>(new IntegerScrambler());
        }

        public bool CanHandle(Type type)
        {
            return type.Equals(typeof(int));
        }

        public void HandleObfuscation(Entity entity, FieldToBeObfuscated field, IEntityMetadataCache metaData)
        {
            // Get the min and maximum values for the field using the meta data cache
            IntegerAttributeMetadata intMetaData = (IntegerAttributeMetadata) metaData.GetAttribute(entity.LogicalName, field.FieldName);
            int min = intMetaData.MinValue.GetValueOrDefault(0);
            int max = intMetaData.MaxValue.GetValueOrDefault(10);
            entity[field.FieldName] = intScramblerClient.ExecuteScramble((int)entity[field.FieldName], min, max);
        }

    }
}
