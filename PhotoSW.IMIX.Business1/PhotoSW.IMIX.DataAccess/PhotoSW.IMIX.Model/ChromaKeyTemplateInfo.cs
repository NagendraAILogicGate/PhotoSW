﻿using System;


namespace PhotoSW.IMIX.Model
    {
    public class ChromaKeyTemplateInfo
        {

        public long ChromaTemplateId
            {
            get;
            set;
            }

        public string Name
            {
            get;
            set;
            }

        public string DisplayName
            {
            get;
            set;
            }

        public string Description
            {
            get;
            set;
            }

        public int CreatedBy
            {
            get;
            set;
            }

        public DateTime CreatedOn
            {
            get;
            set;
            }

        public int ModifiedBy
            {
            get;
            set;
            }

        public DateTime ModifiedOn
            {
            get;
            set;
            }

        public bool IsActive
            {
            get;
            set;
            }

        public string IsActiveDisplay
            {
            get;
            set;
            }

        public long ChromaLength
            {
            get;
            set;
            }
        }
    }
