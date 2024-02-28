namespace FrameworkHelper.RfidLib
{
    using Baracoda.Cameleon.PC.Modularity.Models;
    using System;
    using System.Linq.Expressions;
    using System.Reflection;

    public class BtReaderCached : DataModel
    {
        private string id;
        private string name;

        public string Id
        {
            get
            {
                return this.id;
            }
            set
            {
                if (!string.Equals(this.id, value))
                {
                    this.id = value;
                    base.SendPropertyChanged<string>(Expression.Lambda<Func<string>>(Expression.Property(Expression.Constant(this, typeof(BtReaderCached)), (MethodInfo) methodof(BtReaderCached.get_Id)), new ParameterExpression[0]));
                }
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (!string.Equals(this.name, value))
                {
                    this.name = value;
                    base.SendPropertyChanged<string>(Expression.Lambda<Func<string>>(Expression.Property(Expression.Constant(this, typeof(BtReaderCached)), (MethodInfo) methodof(BtReaderCached.get_Name)), new ParameterExpression[0]));
                }
            }
        }
    }
}

