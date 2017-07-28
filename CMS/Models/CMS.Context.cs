﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace CMS.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class CMSEntities8 : DbContext
    {
        public CMSEntities8()
            : base("name=CMSEntities8")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }
        public virtual DbSet<User> Users { get; set; }
    
        public virtual int addProduct(Nullable<int> userid, string pname, string manufacture, string size, string color, Nullable<int> categoryid, Nullable<decimal> price, Nullable<int> unitinstock)
        {
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(int));
    
            var pnameParameter = pname != null ?
                new ObjectParameter("pname", pname) :
                new ObjectParameter("pname", typeof(string));
    
            var manufactureParameter = manufacture != null ?
                new ObjectParameter("manufacture", manufacture) :
                new ObjectParameter("manufacture", typeof(string));
    
            var sizeParameter = size != null ?
                new ObjectParameter("size", size) :
                new ObjectParameter("size", typeof(string));
    
            var colorParameter = color != null ?
                new ObjectParameter("color", color) :
                new ObjectParameter("color", typeof(string));
    
            var categoryidParameter = categoryid.HasValue ?
                new ObjectParameter("categoryid", categoryid) :
                new ObjectParameter("categoryid", typeof(int));
    
            var priceParameter = price.HasValue ?
                new ObjectParameter("price", price) :
                new ObjectParameter("price", typeof(decimal));
    
            var unitinstockParameter = unitinstock.HasValue ?
                new ObjectParameter("unitinstock", unitinstock) :
                new ObjectParameter("unitinstock", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("addProduct", useridParameter, pnameParameter, manufactureParameter, sizeParameter, colorParameter, categoryidParameter, priceParameter, unitinstockParameter);
        }
    
        public virtual ObjectResult<getCategoryIDs_Result> getCategoryIDs(Nullable<int> parent)
        {
            var parentParameter = parent.HasValue ?
                new ObjectParameter("parent", parent) :
                new ObjectParameter("parent", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getCategoryIDs_Result>("getCategoryIDs", parentParameter);
        }
    
        public virtual ObjectResult<getdata_Result> getdata(Nullable<int> uid, Nullable<int> oid, Nullable<int> pid, Nullable<int> date)
        {
            var uidParameter = uid.HasValue ?
                new ObjectParameter("uid", uid) :
                new ObjectParameter("uid", typeof(int));
    
            var oidParameter = oid.HasValue ?
                new ObjectParameter("oid", oid) :
                new ObjectParameter("oid", typeof(int));
    
            var pidParameter = pid.HasValue ?
                new ObjectParameter("pid", pid) :
                new ObjectParameter("pid", typeof(int));
    
            var dateParameter = date.HasValue ?
                new ObjectParameter("date", date) :
                new ObjectParameter("date", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getdata_Result>("getdata", uidParameter, oidParameter, pidParameter, dateParameter);
        }
    
        public virtual ObjectResult<getInventoryReports_Result> getInventoryReports(Nullable<int> pid, string pname)
        {
            var pidParameter = pid.HasValue ?
                new ObjectParameter("pid", pid) :
                new ObjectParameter("pid", typeof(int));
    
            var pnameParameter = pname != null ?
                new ObjectParameter("pname", pname) :
                new ObjectParameter("pname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getInventoryReports_Result>("getInventoryReports", pidParameter, pnameParameter);
        }
    
        public virtual ObjectResult<getInventoryReportsProductIdFilter_Result> getInventoryReportsProductIdFilter(Nullable<int> pid)
        {
            var pidParameter = pid.HasValue ?
                new ObjectParameter("pid", pid) :
                new ObjectParameter("pid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getInventoryReportsProductIdFilter_Result>("getInventoryReportsProductIdFilter", pidParameter);
        }
    
        public virtual ObjectResult<getInventoryReportsProductNameFilter_Result> getInventoryReportsProductNameFilter(string pname)
        {
            var pnameParameter = pname != null ?
                new ObjectParameter("pname", pname) :
                new ObjectParameter("pname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getInventoryReportsProductNameFilter_Result>("getInventoryReportsProductNameFilter", pnameParameter);
        }
    
        public virtual ObjectResult<getInventoryReportsView_Result> getInventoryReportsView(Nullable<int> pid)
        {
            var pidParameter = pid.HasValue ?
                new ObjectParameter("pid", pid) :
                new ObjectParameter("pid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getInventoryReportsView_Result>("getInventoryReportsView", pidParameter);
        }
    
        public virtual ObjectResult<getOrders_Result> getOrders(Nullable<int> userid)
        {
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getOrders_Result>("getOrders", useridParameter);
        }
    
        public virtual ObjectResult<getOrdersDateFilter_Result> getOrdersDateFilter(Nullable<int> userid, Nullable<int> date)
        {
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(int));
    
            var dateParameter = date.HasValue ?
                new ObjectParameter("date", date) :
                new ObjectParameter("date", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getOrdersDateFilter_Result>("getOrdersDateFilter", useridParameter, dateParameter);
        }
    
        public virtual ObjectResult<getOrdersOrderIdFilter_Result> getOrdersOrderIdFilter(Nullable<int> userid, Nullable<int> orderid)
        {
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(int));
    
            var orderidParameter = orderid.HasValue ?
                new ObjectParameter("orderid", orderid) :
                new ObjectParameter("orderid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getOrdersOrderIdFilter_Result>("getOrdersOrderIdFilter", useridParameter, orderidParameter);
        }
    
        public virtual ObjectResult<getOrdersProductIdFilter_Result> getOrdersProductIdFilter(Nullable<int> userid, Nullable<int> pid)
        {
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(int));
    
            var pidParameter = pid.HasValue ?
                new ObjectParameter("pid", pid) :
                new ObjectParameter("pid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getOrdersProductIdFilter_Result>("getOrdersProductIdFilter", useridParameter, pidParameter);
        }
    
        public virtual ObjectResult<getProBymanufacturer_Result> getProBymanufacturer()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getProBymanufacturer_Result>("getProBymanufacturer");
        }
    
        public virtual int getProByPrice(string action)
        {
            var actionParameter = action != null ?
                new ObjectParameter("action", action) :
                new ObjectParameter("action", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("getProByPrice", actionParameter);
        }
    
        public virtual ObjectResult<getProBySearching_Result> getProBySearching(Nullable<int> userid, string pname)
        {
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(int));
    
            var pnameParameter = pname != null ?
                new ObjectParameter("pname", pname) :
                new ObjectParameter("pname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getProBySearching_Result>("getProBySearching", useridParameter, pnameParameter);
        }
    
        public virtual ObjectResult<getProByUserID_Result> getProByUserID(Nullable<int> userID, Nullable<int> categoryid, Nullable<int> pid)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(int));
    
            var categoryidParameter = categoryid.HasValue ?
                new ObjectParameter("categoryid", categoryid) :
                new ObjectParameter("categoryid", typeof(int));
    
            var pidParameter = pid.HasValue ?
                new ObjectParameter("pid", pid) :
                new ObjectParameter("pid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getProByUserID_Result>("getProByUserID", userIDParameter, categoryidParameter, pidParameter);
        }
    
        public virtual ObjectResult<getProColor_Result> getProColor(Nullable<int> userid, Nullable<int> categoryid, Nullable<int> parent, Nullable<int> pid)
        {
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(int));
    
            var categoryidParameter = categoryid.HasValue ?
                new ObjectParameter("categoryid", categoryid) :
                new ObjectParameter("categoryid", typeof(int));
    
            var parentParameter = parent.HasValue ?
                new ObjectParameter("parent", parent) :
                new ObjectParameter("parent", typeof(int));
    
            var pidParameter = pid.HasValue ?
                new ObjectParameter("pid", pid) :
                new ObjectParameter("pid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getProColor_Result>("getProColor", useridParameter, categoryidParameter, parentParameter, pidParameter);
        }
    
        public virtual ObjectResult<getProSize_Result> getProSize(Nullable<int> userid, Nullable<int> categoryid, Nullable<int> parent, Nullable<int> pid)
        {
            var useridParameter = userid.HasValue ?
                new ObjectParameter("userid", userid) :
                new ObjectParameter("userid", typeof(int));
    
            var categoryidParameter = categoryid.HasValue ?
                new ObjectParameter("categoryid", categoryid) :
                new ObjectParameter("categoryid", typeof(int));
    
            var parentParameter = parent.HasValue ?
                new ObjectParameter("parent", parent) :
                new ObjectParameter("parent", typeof(int));
    
            var pidParameter = pid.HasValue ?
                new ObjectParameter("pid", pid) :
                new ObjectParameter("pid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getProSize_Result>("getProSize", useridParameter, categoryidParameter, parentParameter, pidParameter);
        }
    
        public virtual ObjectResult<getSalesReports_Result> getSalesReports(Nullable<int> pid)
        {
            var pidParameter = pid.HasValue ?
                new ObjectParameter("pid", pid) :
                new ObjectParameter("pid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getSalesReports_Result>("getSalesReports", pidParameter);
        }
    
        public virtual ObjectResult<getSalesReportsProductIdFilter_Result> getSalesReportsProductIdFilter(Nullable<int> pid)
        {
            var pidParameter = pid.HasValue ?
                new ObjectParameter("pid", pid) :
                new ObjectParameter("pid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getSalesReportsProductIdFilter_Result>("getSalesReportsProductIdFilter", pidParameter);
        }
    
        public virtual int OrdersUpdateDelete(Nullable<int> orderid, string shipstatus)
        {
            var orderidParameter = orderid.HasValue ?
                new ObjectParameter("orderid", orderid) :
                new ObjectParameter("orderid", typeof(int));
    
            var shipstatusParameter = shipstatus != null ?
                new ObjectParameter("shipstatus", shipstatus) :
                new ObjectParameter("shipstatus", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("OrdersUpdateDelete", orderidParameter, shipstatusParameter);
        }
    }
}
