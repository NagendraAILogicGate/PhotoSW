using PhotoSW.IMIX.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Threading;
using DigiPhoto;

namespace PhotoSW.Calender
{
    public class ItemTemplateCalenderView : ViewModelBase, IDisposable
    {
        public delegate void OperationDoneHandler(ItemTemplateCalenderView sender, CalenderViewOperationType operation);

        private List<ItemTemplateMaster> _ItemTemplateCalender;

        private List<LstMyItems> _PrintImages;

        private ObservableCollection<PrintOrderPage> _PrintOrderPageList;

        private ItemTemplateMaster _ItemTemplateCalenderLastSelected;

        private ItemTemplateMaster _ItemTemplateCalenderSelected;

        private ObservableCollection<LstMyItems> _LstMyItems;
        private ItemTemplateCalenderView.OperationDoneHandler operationDoneEvent;
        public event ItemTemplateCalenderView.OperationDoneHandler OperationDoneEvent
        {
            add
            {
                do
                {
                IL_00:
                    ItemTemplateCalenderView.OperationDoneHandler operationDoneHandler = this.operationDoneEvent;
                    while (true)
                    {
                    IL_09:
                        ItemTemplateCalenderView.OperationDoneHandler operationDoneHandler2 = operationDoneHandler;
                        while (true)
                        {
                            ItemTemplateCalenderView.OperationDoneHandler value2 = (ItemTemplateCalenderView.OperationDoneHandler)Delegate.Combine(operationDoneHandler2, value);
                            if (-1 == 0)
                            {
                                goto IL_00;
                            }
                            operationDoneHandler = Interlocked.CompareExchange<ItemTemplateCalenderView.OperationDoneHandler>(ref this.operationDoneEvent, value2, operationDoneHandler2);
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
                    ItemTemplateCalenderView.OperationDoneHandler operationDoneHandler = this.operationDoneEvent;
                    while (true)
                    {
                    IL_09:
                        ItemTemplateCalenderView.OperationDoneHandler operationDoneHandler2 = operationDoneHandler;
                        while (true)
                        {
                            ItemTemplateCalenderView.OperationDoneHandler value2 = (ItemTemplateCalenderView.OperationDoneHandler)Delegate.Remove(operationDoneHandler2, value);
                            if (-1 == 0)
                            {
                                goto IL_00;
                            }
                            operationDoneHandler = Interlocked.CompareExchange<ItemTemplateCalenderView.OperationDoneHandler>(ref this.operationDoneEvent, value2, operationDoneHandler2);
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

        public List<ItemTemplateMaster> ItemTemplateCalender
        {
            get
            {
                return this._ItemTemplateCalender;
            }
            set
            {
                base.NotifyPropertyChanging(MethodBase.GetCurrentMethod().Name);
                this._ItemTemplateCalender = value;
                base.NotifyPropertyChanged(MethodBase.GetCurrentMethod().Name);
            }
        }

        public List<LstMyItems> PrintImages
        {
            get
            {
                return this._PrintImages;
            }
            set
            {
                base.NotifyPropertyChanging(MethodBase.GetCurrentMethod().Name);
                this._PrintImages = value;
                base.NotifyPropertyChanged(MethodBase.GetCurrentMethod().Name);
            }
        }

        public ObservableCollection<PrintOrderPage> PrintOrderPageList
        {
            get
            {
                return this._PrintOrderPageList;
            }
            set
            {
                base.NotifyPropertyChanging(MethodBase.GetCurrentMethod().Name);
                this._PrintOrderPageList = value;
                base.NotifyPropertyChanged(MethodBase.GetCurrentMethod().Name);
            }
        }

        public ItemTemplateMaster ItemTemplateCalenderSelected
        {
            get
            {
                return this._ItemTemplateCalenderSelected;
            }
            set
            {
                while (true)
                {
                    while (true)
                    {
                        base.NotifyPropertyChanging(MethodBase.GetCurrentMethod().Name);
                        while (!false)
                        {
                            this._ItemTemplateCalenderLastSelected = this._ItemTemplateCalenderSelected;
                            do
                            {
                                if (8 != 0)
                                {
                                    this._ItemTemplateCalenderSelected = value;
                                    this.BuildDetailItems();
                                }
                            }
                            while (3 == 0);
                            if (2 == 0)
                            {
                                break;
                            }
                            if (6 != 0)
                            {
                                goto Block_4;
                            }
                        }
                    }
                }
            Block_4:
                base.NotifyPropertyChanged(MethodBase.GetCurrentMethod().Name);
            }
        }

        public ObservableCollection<LstMyItems> LstMyItems
        {
            get
            {
                return this._LstMyItems;
            }
            set
            {
                base.NotifyPropertyChanging(MethodBase.GetCurrentMethod().Name);
                this._LstMyItems = value;
                base.NotifyPropertyChanged(MethodBase.GetCurrentMethod().Name);
            }
        }

        public ItemTemplateCalenderView()
        {
            this.PrintImages = RobotImageLoader.PrintImages;
            this.ItemTemplateCalender = new List<ItemTemplateMaster>();
            this.PrintOrderPageList = new ObservableCollection<PrintOrderPage>();
        }

        private void BuildDetailItems()
        {
            while (true)
            {
                if (this._ItemTemplateCalenderSelected != null)
                {
                    if (!false)
                    {
                        goto IL_15;
                    }
                    continue;
                }
            IL_23:
                if (8 != 0)
                {
                    if (!false)
                    {
                        break;
                    }
                    continue;
                }
            IL_15:
                this._ItemTemplateCalenderSelected.LoadDetailsAsync();
                if (!false)
                {
                }
                goto IL_23;
            }
        }

        public void CopyMyListItem(LstMyItems source, ItemTemplateDetail destination, bool canCopyListPosition = false)
        {
            bool flag;
            if (3 != 0)
            {
                flag = (destination == null);
                if (flag)
                {
                    return;
                }
                destination.AssociationPhotoId = source.PhotoId;
                destination.AssociationPhotoName = source.Name;
                destination.AssociationPhotoFileName = source.FileName;
                destination.AssociationPhotoFilePath = source.FilePath.Replace("Thumbnails", "Thumbnails_Big");
            }
            if (8 != 0)
            {
                if (3 == 0)
                {
                    goto IL_7D;
                }
                bool arg_74_0 = canCopyListPosition;
                bool expr_74;
                do
                {
                    expr_74 = (arg_74_0 = !arg_74_0);
                }
                while (false);
                flag = expr_74;
            }
            if (flag)
            {
                return;
            }
        IL_7D:
            destination.FileOrder = source.ListPosition;
        }

        public void CopyItemTemplateDetail(ItemTemplateDetail source, ItemTemplateDetail destination, bool canCopyListPosition = false)
        {
            bool flag = destination == null;
            if (!false)
            {
                bool arg_0D_0 = flag;
                while (!arg_0D_0)
                {
                    destination.AssociationPhotoId = source.AssociationPhotoId;
                    destination.AssociationPhotoName = source.AssociationPhotoName;
                    destination.AssociationPhotoFileName = source.AssociationPhotoFileName;
                    destination.AssociationPhotoFilePath = source.AssociationPhotoFilePath;
                    arg_0D_0 = canCopyListPosition;
                    if (!false)
                    {
                        if (canCopyListPosition)
                        {
                            destination.FileOrder = source.FileOrder;
                            break;
                        }
                        break;
                    }
                }
            }
        }

        public void LoadCalenderTemplate(string basePath = null)
        {
            do
            {
                this.ItemTemplateCalender = ItemTemplateMaster.GetItemCalenderMaster(null);
                if (string.IsNullOrWhiteSpace(basePath))
                {
                    break;
                }
                while (5 == 0)
                {
                }
                List<ItemTemplateMaster>.Enumerator enumerator = this.ItemTemplateCalender.GetEnumerator();
                try
                {
                    if (!false)
                    {
                        if (false)
                        {
                            goto IL_7B;
                        }
                    }
                IL_6C:
                    bool arg_79_0;
                    bool expr_6F = arg_79_0 = enumerator.MoveNext();
                    if (4 != 0)
                    {
                        bool flag = expr_6F;
                        arg_79_0 = flag;
                    }
                    if (arg_79_0)
                    {
                        ItemTemplateMaster current = enumerator.Current;
                        current.BasePath = basePath;
                        current.OperationDoneEvent += new ItemTemplateMaster.OperationDoneHandler(this._ItemTemplateCalender_OperationDoneEvent);
                        goto IL_6C;
                    }
                IL_7B: ;
                }
                finally
                {
                    do
                    {
                        ((IDisposable)enumerator).Dispose();
                    }
                    while (8 == 0);
                }
            }
            while (5 == 0);
        }

        private void _ItemTemplateCalender_OperationDoneEvent(ItemTemplateMaster sender, CalenderViewOperationType operation)
        {
            bool flag;
            do
            {
                bool arg_10D_0;
                if (operation == CalenderViewOperationType.LoadCalenderDetailData)
                {
                    arg_10D_0 = (this._ItemTemplateCalenderLastSelected == null);
                }
                else
                {
                    if (false)
                    {
                        goto IL_EF;
                    }
                    arg_10D_0 = true;
                }
                flag = arg_10D_0;
                if (!flag)
                {
                    IEnumerator<ItemTemplateDetail> enumerator = this._ItemTemplateCalenderLastSelected.ItemTemplateDetailList.GetEnumerator();
                    try
                    {
                        while (true)
                        {
                            if (7 == 0)
                            {
                                goto IL_A9;
                            }
                            flag = enumerator.MoveNext();
                            if (!flag)
                            {
                                break;
                            }
                        IL_52:
                            ItemTemplateDetail previousDetail = enumerator.Current;
                            flag = (sender.ItemTemplateDetailList == null);
                            if (!flag)
                            {
                                ItemTemplateDetail destination = (from i in sender.ItemTemplateDetailList
                                                                  where i.FileOrder == previousDetail.FileOrder
                                                                  select i).SingleOrDefault<ItemTemplateDetail>();
                                if (false)
                                {
                                    continue;
                                }
                                this.CopyItemTemplateDetail(previousDetail, destination, false);
                            }
                        IL_AB:
                            if (!false)
                            {
                                continue;
                            }
                            goto IL_52;
                        IL_A9:
                            goto IL_AB;
                        }
                    }
                    finally
                    {
                        flag = (enumerator == null);
                        if (!flag)
                        {
                            enumerator.Dispose();
                        }
                    }
                    if (!false)
                    {
                    }
                }
            }
            while (false);
            flag = (this.operationDoneEvent == null);
        IL_EF:
            if (!flag)
            {
                this.operationDoneEvent(this, CalenderViewOperationType.LoadCalenderDetailData);
            }
        }

        public void Dispose()
        {
            if (-1 == 0)
            {
                goto IL_23;
            }
            List<LstMyItems> expr_06 = null;
            if (4 != 0)
            {
                this.PrintImages = expr_06;
            }
        IL_0C:
            bool flag = this.ItemTemplateCalender == null;
        IL_16:
            if (!flag)
            {
                List<ItemTemplateMaster> expr_4F = this.ItemTemplateCalender;
                if (!false)
                {
                    expr_4F.Clear();
                }
            }
        IL_23:
            this.ItemTemplateCalender = null;
            if (5 == 0)
            {
                goto IL_0C;
            }
            if (!false)
            {
                return;
            }
            goto IL_16;
        }
    }
}
