namespace DigiPhoto.Manage.Reports.rpt
{
    using CrystalDecisions.CrystalReports.Engine;
    using CrystalDecisions.ReportSource;
    using CrystalDecisions.Shared;
    using System;
    using System.ComponentModel;
    using System.Drawing;

    [ToolboxBitmap(typeof(ExportOptions), "report.bmp")]
    public class CachedIPContentTrackingReport : Component, ICachedReport
    {
        public virtual ReportDocument CreateReport()
        {
            // This item is obfuscated and can not be translated.
        }

        public virtual string GetCustomizedCacheKey(RequestContext request)
        {
            // This item is obfuscated and can not be translated.
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public virtual TimeSpan CacheTimeOut
        {
            get
            {
                // This item is obfuscated and can not be translated.
            }
            set
            {
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool IsCacheable
        {
            get
            {
                // This item is obfuscated and can not be translated.
            }
            set
            {
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public virtual bool ShareDBLogonInfo
        {
            get
            {
                // This item is obfuscated and can not be translated.
            }
            set
            {
            }
        }
    }
}

