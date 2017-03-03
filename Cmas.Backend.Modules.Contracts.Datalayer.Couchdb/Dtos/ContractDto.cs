﻿using System;

namespace Cmas.Backend.Modules.Contracts.Datalayer.Couchdb.Dtos
{
    public class ContractDto
    {
        public String Name;
        public String Number;
        public String StartDate;
        public String FinishDate;
        public String ContractorName;
        public String Currency;
        public String Amount;
        public bool VatIncluded;
        public String ConstructionObjectName;
        public String ConstructionObjectTitleName;
        public String ConstructionObjectTitleCode;
        public String Description;
    }
}
