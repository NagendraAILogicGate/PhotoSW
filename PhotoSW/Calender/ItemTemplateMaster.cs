using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace PhotoSW.Calender
{
    public class ItemTemplateMaster : INotifyPropertyChanged, INotifyPropertyChanging
    {
        public delegate List<ItemTemplateDetail> LoadDetailsHandler();

        public delegate void OperationDoneHandler(ItemTemplateMaster sender, CalenderViewOperationType operation);

        public string _BasePath;

        public ObservableCollection<ItemTemplateDetail> _ItemTemplateDetailList;

        private PropertyChangedEventHandler propertyChanged;
        private PropertyChangingEventHandler propertyChanging;
        public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {
                do
                {
                IL_00:
                    PropertyChangedEventHandler propertyChangedEventHandler = this.propertyChanged;
                    while (true)
                    {
                    IL_09:
                        PropertyChangedEventHandler propertyChangedEventHandler2 = propertyChangedEventHandler;
                        while (true)
                        {
                            PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
                            if (-1 == 0)
                            {
                                goto IL_00;
                            }
                            propertyChangedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.propertyChanged, value2, propertyChangedEventHandler2);
                            while (!false)
                            {
                                bool arg_39_0;
                                bool expr_31 = arg_39_0 = (propertyChangedEventHandler == propertyChangedEventHandler2);
                                if (!false)
                                {
                                    arg_39_0 = !expr_31;
                                }
                                if (arg_39_0)
                                {
                                    goto IL_09;
                                }
                                if (!false)
                                {
                                    goto Block_4;
                                }
                            }
                        }
                    }
                Block_4: ;
                }
                while (!true);
            }
            remove
            {
                do
                {
                IL_00:
                    PropertyChangedEventHandler propertyChangedEventHandler = this.propertyChanged;
                    while (true)
                    {
                    IL_09:
                        PropertyChangedEventHandler propertyChangedEventHandler2 = propertyChangedEventHandler;
                        while (true)
                        {
                            PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
                            if (-1 == 0)
                            {
                                goto IL_00;
                            }
                            propertyChangedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.propertyChanged, value2, propertyChangedEventHandler2);
                            while (!false)
                            {
                                bool arg_39_0;
                                bool expr_31 = arg_39_0 = (propertyChangedEventHandler == propertyChangedEventHandler2);
                                if (!false)
                                {
                                    arg_39_0 = !expr_31;
                                }
                                if (arg_39_0)
                                {
                                    goto IL_09;
                                }
                                if (!false)
                                {
                                    goto Block_4;
                                }
                            }
                        }
                    }
                Block_4: ;
                }
                while (!true);
            }
        }

        public event PropertyChangingEventHandler PropertyChanging
        {
            add
            {
                do
                {
                IL_00:
                    PropertyChangingEventHandler propertyChangingEventHandler = this.propertyChanging;
                    while (true)
                    {
                    IL_09:
                        PropertyChangingEventHandler propertyChangingEventHandler2 = propertyChangingEventHandler;
                        while (true)
                        {
                            PropertyChangingEventHandler value2 = (PropertyChangingEventHandler)Delegate.Combine(propertyChangingEventHandler2, value);
                            if (-1 == 0)
                            {
                                goto IL_00;
                            }
                            propertyChangingEventHandler = Interlocked.CompareExchange<PropertyChangingEventHandler>(ref this.propertyChanging, value2, propertyChangingEventHandler2);
                            while (!false)
                            {
                                bool arg_39_0;
                                bool expr_31 = arg_39_0 = (propertyChangingEventHandler == propertyChangingEventHandler2);
                                if (!false)
                                {
                                    arg_39_0 = !expr_31;
                                }
                                if (arg_39_0)
                                {
                                    goto IL_09;
                                }
                                if (!false)
                                {
                                    goto Block_4;
                                }
                            }
                        }
                    }
                Block_4: ;
                }
                while (!true);
            }
            remove
            {
                do
                {
                IL_00:
                    PropertyChangingEventHandler propertyChangingEventHandler = this.propertyChanging;
                    while (true)
                    {
                    IL_09:
                        PropertyChangingEventHandler propertyChangingEventHandler2 = propertyChangingEventHandler;
                        while (true)
                        {
                            PropertyChangingEventHandler value2 = (PropertyChangingEventHandler)Delegate.Remove(propertyChangingEventHandler2, value);
                            if (-1 == 0)
                            {
                                goto IL_00;
                            }
                            propertyChangingEventHandler = Interlocked.CompareExchange<PropertyChangingEventHandler>(ref this.propertyChanging, value2, propertyChangingEventHandler2);
                            while (!false)
                            {
                                bool arg_39_0;
                                bool expr_31 = arg_39_0 = (propertyChangingEventHandler == propertyChangingEventHandler2);
                                if (!false)
                                {
                                    arg_39_0 = !expr_31;
                                }
                                if (arg_39_0)
                                {
                                    goto IL_09;
                                }
                                if (!false)
                                {
                                    goto Block_4;
                                }
                            }
                        }
                    }
                Block_4: ;
                }
                while (!true);
            }
        }
        private ItemTemplateMaster.OperationDoneHandler operationDoneEvent;
        public event ItemTemplateMaster.OperationDoneHandler OperationDoneEvent
        {
            add
            {
                do
                {
                IL_00:
                    ItemTemplateMaster.OperationDoneHandler operationDoneHandler = this.operationDoneEvent;
                    while (true)
                    {
                    IL_09:
                        ItemTemplateMaster.OperationDoneHandler operationDoneHandler2 = operationDoneHandler;
                        while (true)
                        {
                            ItemTemplateMaster.OperationDoneHandler value2 = (ItemTemplateMaster.OperationDoneHandler)Delegate.Combine(operationDoneHandler2, value);
                            if (-1 == 0)
                            {
                                goto IL_00;
                            }
                            operationDoneHandler = Interlocked.CompareExchange<ItemTemplateMaster.OperationDoneHandler>(ref this.operationDoneEvent, value2, operationDoneHandler2);
                            while (!false)
                            {
                                bool arg_39_0;
                                bool expr_31 = arg_39_0 = (operationDoneHandler == operationDoneHandler2);
                                if (!false)
                                {
                                    arg_39_0 = !expr_31;
                                }
                                if (arg_39_0)
                                {
                                    goto IL_09;
                                }
                                if (!false)
                                {
                                    goto Block_4;
                                }
                            }
                        }
                    }
                Block_4: ;
                }
                while (!true);
            }
            remove
            {
                do
                {
                IL_00:
                    ItemTemplateMaster.OperationDoneHandler operationDoneHandler = this.operationDoneEvent;
                    while (true)
                    {
                    IL_09:
                        ItemTemplateMaster.OperationDoneHandler operationDoneHandler2 = operationDoneHandler;
                        while (true)
                        {
                            ItemTemplateMaster.OperationDoneHandler value2 = (ItemTemplateMaster.OperationDoneHandler)Delegate.Remove(operationDoneHandler2, value);
                            if (-1 == 0)
                            {
                                goto IL_00;
                            }
                            operationDoneHandler = Interlocked.CompareExchange<ItemTemplateMaster.OperationDoneHandler>(ref this.operationDoneEvent, value2, operationDoneHandler2);
                            while (!false)
                            {
                                bool arg_39_0;
                                bool expr_31 = arg_39_0 = (operationDoneHandler == operationDoneHandler2);
                                if (!false)
                                {
                                    arg_39_0 = !expr_31;
                                }
                                if (arg_39_0)
                                {
                                    goto IL_09;
                                }
                                if (!false)
                                {
                                    goto Block_4;
                                }
                            }
                        }
                    }
                Block_4: ;
                }
                while (!true);
            }
        }

        public int Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public int SubtemplateCount
        {
            get;
            set;
        }

        public int PathType
        {
            get;
            set;
        }

        public int TemplateType
        {
            get;
            set;
        }

        public string ThumbnailImagePath
        {
            get;
            set;
        }

        public string ThumbnailImageName
        {
            get;
            set;
        }

        public int Status
        {
            get;
            set;
        }

        public ICollection<ItemTemplateDetail> ItemTemplateDetails
        {
            get;
            set;
        }

        public virtual ICollection<ItemTemplatePrintOrder> ItemTemplatePrintOrders
        {
            get;
            set;
        }

        public string BasePath
        {
            get
            {
                return this._BasePath;
            }
            set
            {
                bool arg_16_0;
                bool arg_25_0 = arg_16_0 = (this._BasePath != value);
                do
                {
                    if (!false)
                    {
                        bool flag = !arg_16_0;
                        arg_25_0 = (arg_16_0 = flag);
                    }
                }
                while (false);
                if (!arg_25_0)
                {
                    while (true)
                    {
                    IL_28:
                        this.NotifyPropertyChanging(MethodBase.GetCurrentMethod().Name);
                        while (7 != 0)
                        {
                            this.NotifyPropertyChanging("ThumbnailImageFullPath");
                            if (!false)
                            {
                                this._BasePath = value;
                                this.NotifyPropertyChanged("ThumbnailImageFullPath");
                                if (!false)
                                {
                                    goto Block_5;
                                }
                                goto IL_28;
                            }
                        }
                        goto IL_6C;
                    }
                Block_5:
                    this.NotifyPropertyChanged(MethodBase.GetCurrentMethod().Name);
                IL_6C: ;
                }
            }
        }

        public ObservableCollection<ItemTemplateDetail> ItemTemplateDetailList
        {
            get
            {
                return this._ItemTemplateDetailList;
            }
            set
            {
                this.NotifyPropertyChanging(MethodBase.GetCurrentMethod().Name);
                this._ItemTemplateDetailList = value;
                this.NotifyPropertyChanged(MethodBase.GetCurrentMethod().Name);
            }
        }

        public string ThumbnailImageFullPath
        {
            get
            {
                string arg_1C_0;
                if (!false)
                {
                    string text = this.BasePath + this.ThumbnailImagePath;
                    if (File.Exists(text))
                    {
                        arg_1C_0 = text;
                        return arg_1C_0;
                    }
                }
                arg_1C_0 = null;
                return arg_1C_0;
            }
        }

        public ItemTemplateMaster()
        {
            this.ItemTemplateDetails = new HashSet<ItemTemplateDetail>();
            this.ItemTemplatePrintOrders = new HashSet<ItemTemplatePrintOrder>();
        }

        public void LoadDetailsAsync()
        {
            ItemTemplateMaster.LoadDetailsHandler expr_09 = new ItemTemplateMaster.LoadDetailsHandler(this.LoadDetails);
            ItemTemplateMaster.LoadDetailsHandler loadDetailsHandler;
            if (!false)
            {
                loadDetailsHandler = expr_09;
            }
            loadDetailsHandler.BeginInvoke(new AsyncCallback(this.LoadDetailsCallback), null);
        }

        public List<ItemTemplateDetail> LoadDetails()
        {
            List<ItemTemplateDetail> result;
            while (!false)
            {
                List<ItemTemplateDetail> list;
                if (6 != 0)
                {
                    list = new List<ItemTemplateDetail>();
                    List<ItemTemplateDetailModel> list2 = new List<ItemTemplateDetailModel>();
                    if (false)
                    {
                        continue;
                    }
                    List<ItemTemplateDetailModel> expr_1AE = new CalenderBusiness().GetItemTemplateDetail();
                    if (!false)
                    {
                        list2 = expr_1AE;
                    }
                    if (2 == 0)
                    {
                        break;
                    }
                    List<ItemTemplateDetailModel>.Enumerator enumerator = list2.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            ItemTemplateDetailModel current = enumerator.Current;
                            ItemTemplateDetail item = new ItemTemplateDetail
                            {
                                AssociationPhotoFileName = current.AssociationPhotoFileName,
                                AssociationPhotoFilePath = current.AssociationPhotoFilePath,
                                AssociationPhotoId = current.AssociationPhotoId,
                                AssociationPhotoName = current.AssociationPhotoName,
                                FileName = current.FileName,
                                FileOrder = current.FileOrder,
                                FilePath = current.FilePath,
                                I1_X1 = current.I1_X1,
                                I1_X2 = current.I1_X2,
                                I1_Y1 = current.I1_Y1,
                                I1_Y2 = current.I1_Y2,
                                Id = current.Id,
                                MasterTemplateId = current.MasterTemplateId,
                                Status = current.Status,
                                TemplateType = current.TemplateType
                            };
                            list.Add(item);
                        }
                    }
                    finally
                    {
                        do
                        {
                            ((IDisposable)enumerator).Dispose();
                            if (!false)
                            {
                            }
                        }
                        while (false);
                    }
                }
                result = (from x in list
                          where x.MasterTemplateId == this.Id
                          select x).ToList<ItemTemplateDetail>();
            IL_17C:
                break;
            }
            if (7 != 0)
            {
                return result;
            }
            //goto IL_17C;
        }

        public void LoadDetailsCallback(IAsyncResult result)
        {
            AsyncResult asyncResult = result as AsyncResult;
            object obj;
            if (4 != 0)
            {
                ItemTemplateMaster.LoadDetailsHandler loadDetailsHandler = asyncResult.AsyncDelegate as ItemTemplateMaster.LoadDetailsHandler;
                obj = loadDetailsHandler.EndInvoke(result);
            }
            this.ItemTemplateDetailList = new ObservableCollection<ItemTemplateDetail>(obj as List<ItemTemplateDetail>);
            if (this.operationDoneEvent != null)
            {
                this.operationDoneEvent(this, CalenderViewOperationType.LoadCalenderDetailData);
            }
        }

        public void SetBaseFilePath(string basePath)
        {
            this.BasePath = basePath;
        }

        public static List<ItemTemplateMaster> GetItemTemplateMaster(Expression<Func<ItemTemplateMaster, bool>> filter = null)
        {
            List<ItemTemplateMaster> result;
            do
            {
                List<ItemTemplateMaster> expr_01 = null;
                List<ItemTemplateMaster> list;
                if (2 != 0)
                {
                    list = expr_01;
                }
                CalenderBusiness calenderBusiness = new CalenderBusiness();
                List<ItemTemplateMasterModel> itemTemplateMaster = calenderBusiness.GetItemTemplateMaster();
                List<ItemTemplateDetailModel> itemTemplateDetail = calenderBusiness.GetItemTemplateDetail();
                List<ItemTemplateMasterModel>.Enumerator enumerator = itemTemplateMaster.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        ItemTemplateMasterModel current;
                        ItemTemplateMaster itemTemplateMaster2;
                        while (true)
                        {
                            current = enumerator.Current;
                            if (-1 == 0)
                            {
                                break;
                            }
                            itemTemplateMaster2 = new ItemTemplateMaster();
                            if (2 != 0)
                            {
                                goto Block_4;
                            }
                        }
                    IL_F9:
                        ItemTemplateMaster item;
                        list.Add(item);
                        continue;
                    Block_4:
                        itemTemplateMaster2.Id = current.Id;
                        itemTemplateMaster2.Name = current.Name;
                        itemTemplateMaster2.Description = current.Description;
                        itemTemplateMaster2.SubtemplateCount = current.SubtemplateCount;
                        itemTemplateMaster2.PathType = current.PathType;
                        itemTemplateMaster2.TemplateType = current.TemplateType;
                        itemTemplateMaster2.ThumbnailImagePath = current.ThumbnailImagePath;
                        itemTemplateMaster2.ThumbnailImageName = current.ThumbnailImageName;
                        itemTemplateMaster2.Status = current.Status;
                        itemTemplateMaster2.ItemTemplateDetails = ItemTemplateMaster.CopyItemTemplateDetailsFromImix(itemTemplateDetail, current.Id);
                        item = itemTemplateMaster2;
                        goto IL_F9;
                    }
                }
                finally
                {
                    if (!false)
                    {
                        ((IDisposable)enumerator).Dispose();
                        if (!false)
                        {
                        }
                    }
                }
                result = list;
            }
            while (false);
            return result;
        }

        public static List<ItemTemplateMaster> GetItemCalenderMaster(Expression<Func<ItemTemplateMaster, bool>> filter = null)
        {
            List<ItemTemplateMaster> expr_1A8 = new List<ItemTemplateMaster>();
            List<ItemTemplateMaster> list;
            if (4 != 0)
            {
                list = expr_1A8;
            }
            CalenderBusiness calenderBusiness = new CalenderBusiness();
            List<ItemTemplateMasterModel> itemTemplateMaster = calenderBusiness.GetItemTemplateMaster();
            List<ItemTemplateDetailModel> itemTemplateDetail = calenderBusiness.GetItemTemplateDetail();
            if (!false)
            {
                foreach (ItemTemplateMasterModel current in itemTemplateMaster)
                {
                    ItemTemplateMaster itemTemplateMaster2;
                    while (true)
                    {
                        itemTemplateMaster2 = new ItemTemplateMaster();
                        while (true)
                        {
                            itemTemplateMaster2.Id = current.Id;
                            if (8 == 0)
                            {
                                goto IL_116;
                            }
                            itemTemplateMaster2.Name = current.Name;
                            itemTemplateMaster2.Description = current.Description;
                            if (!false)
                            {
                            }
                            if (false)
                            {
                                break;
                            }
                            itemTemplateMaster2.SubtemplateCount = current.SubtemplateCount;
                            if (!true)
                            {
                                break;
                            }
                            itemTemplateMaster2.PathType = current.PathType;
                            do
                            {
                                itemTemplateMaster2.TemplateType = current.TemplateType;
                                itemTemplateMaster2.ThumbnailImagePath = current.ThumbnailImagePath;
                                itemTemplateMaster2.ThumbnailImageName = current.ThumbnailImageName;
                            }
                            while (-1 == 0);
                            itemTemplateMaster2.Status = current.Status;
                            if (!false)
                            {
                                goto Block_11;
                            }
                        }
                    }
                IL_116:
                    continue;
                Block_11:
                    itemTemplateMaster2.ItemTemplateDetails = ItemTemplateMaster.CopyItemTemplateDetailsFromImix(itemTemplateDetail, current.Id);
                    ItemTemplateMaster item = itemTemplateMaster2;
                    list.Add(item);
                }
                if (filter != null)
                {
                    list = (from i in list
                            where i.TemplateType == 1
                            select i).ToList<ItemTemplateMaster>();
                    return list;
                }
            }
            list = (from i in list
                    where i.TemplateType == 1
                    select i).ToList<ItemTemplateMaster>();
            return list;
        }

        protected void NotifyPropertyChanged(string info)
        {
            do
            {
                info = info.Replace("get_", "").Replace("set_", "");
                if (!false)
                {
                    bool arg_34_0;
                    bool expr_28 = arg_34_0 = (this.propertyChanged == null);
                    if (!false)
                    {
                        bool flag = expr_28;
                        if (false)
                        {
                            goto IL_36;
                        }
                        arg_34_0 = flag;
                    }
                    if (arg_34_0)
                    {
                        break;
                    }
                }
            IL_36:
                this.propertyChanged(this, new PropertyChangedEventArgs(info));
            }
            while (2 == 0);
        }

        protected void NotifyPropertyChanging(string info)
        {
            do
            {
                info = info.Replace("get_", "").Replace("set_", "");
                if (!false)
                {
                    bool arg_34_0;
                    bool expr_28 = arg_34_0 = (this.propertyChanging == null);
                    if (!false)
                    {
                        bool flag = expr_28;
                        if (false)
                        {
                            goto IL_36;
                        }
                        arg_34_0 = flag;
                    }
                    if (arg_34_0)
                    {
                        break;
                    }
                }
            IL_36:
                this.propertyChanging(this, new PropertyChangingEventArgs(info));
            }
            while (2 == 0);
        }

        private static List<ItemTemplateDetail> CopyItemTemplateDetailsFromImix(List<ItemTemplateDetailModel> lstItemDetail, int idImix)
        {
            List<ItemTemplateDetail> list = new List<ItemTemplateDetail>();
            List<ItemTemplateDetailModel> list2 = (from x in lstItemDetail
                                                   where x.MasterTemplateId == idImix
                                                   select x).ToList<ItemTemplateDetailModel>();
            using (List<ItemTemplateDetailModel>.Enumerator enumerator = list2.GetEnumerator())
            {
                while (true)
                {
                IL_17B:
                    bool flag = enumerator.MoveNext();
                    while (flag)
                    {
                        ItemTemplateDetailModel current = enumerator.Current;
                        if (!false)
                        {
                            ItemTemplateDetail itemTemplateDetail = new ItemTemplateDetail();
                            itemTemplateDetail.AssociationPhotoFileName = current.AssociationPhotoFileName;
                            itemTemplateDetail.AssociationPhotoFilePath = current.AssociationPhotoFilePath;
                            itemTemplateDetail.AssociationPhotoId = current.AssociationPhotoId;
                            itemTemplateDetail.AssociationPhotoName = current.AssociationPhotoName;
                            itemTemplateDetail.FileName = current.FileName;
                            itemTemplateDetail.FileNameWithotExtension = current.FileName.Replace(".jpg", string.Empty).Replace(".JPG", string.Empty);
                            itemTemplateDetail.FileOrder = current.FileOrder;
                            if (!false)
                            {
                                itemTemplateDetail.FilePath = current.FilePath;
                                itemTemplateDetail.I1_X1 = current.I1_X1;
                                itemTemplateDetail.I1_X2 = current.I1_X2;
                                goto IL_115;
                            }
                            ItemTemplateDetail item;
                            do
                            {
                            IL_131:
                                itemTemplateDetail.Id = current.Id;
                                itemTemplateDetail.MasterTemplateId = current.MasterTemplateId;
                                itemTemplateDetail.Status = current.Status;
                                itemTemplateDetail.TemplateType = current.TemplateType;
                                if (3 == 0)
                                {
                                    goto IL_115;
                                }
                                item = itemTemplateDetail;
                            }
                            while (3 == 0);
                            list.Add(item);
                            goto IL_17B;
                        IL_115:
                            itemTemplateDetail.I1_Y1 = current.I1_Y1;
                            itemTemplateDetail.I1_Y2 = current.I1_Y2;
                            //goto IL_131;
                        }
                    }
                    break;
                }
            }
            return list;
        }
    }
}
