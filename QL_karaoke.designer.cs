﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace quanLyQuanKara
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="QLKaraoke")]
	public partial class QL_karaokeDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Insertaccount(account instance);
    partial void Updateaccount(account instance);
    partial void Deleteaccount(account instance);
    partial void Insertbill(bill instance);
    partial void Updatebill(bill instance);
    partial void Deletebill(bill instance);
    partial void InsertbillInfo(billInfo instance);
    partial void UpdatebillInfo(billInfo instance);
    partial void DeletebillInfo(billInfo instance);
    partial void InsertfoodCategory(foodCategory instance);
    partial void UpdatefoodCategory(foodCategory instance);
    partial void DeletefoodCategory(foodCategory instance);
    partial void Insertfood(food instance);
    partial void Updatefood(food instance);
    partial void Deletefood(food instance);
    partial void InsertRoom(Room instance);
    partial void UpdateRoom(Room instance);
    partial void DeleteRoom(Room instance);
    #endregion
		
		public QL_karaokeDataContext() : 
				base(global::quanLyQuanKara.Properties.Settings.Default.QLKaraokeConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public QL_karaokeDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public QL_karaokeDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public QL_karaokeDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public QL_karaokeDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<account> accounts
		{
			get
			{
				return this.GetTable<account>();
			}
		}
		
		public System.Data.Linq.Table<bill> bills
		{
			get
			{
				return this.GetTable<bill>();
			}
		}
		
		public System.Data.Linq.Table<billInfo> billInfos
		{
			get
			{
				return this.GetTable<billInfo>();
			}
		}
		
		public System.Data.Linq.Table<foodCategory> foodCategories
		{
			get
			{
				return this.GetTable<foodCategory>();
			}
		}
		
		public System.Data.Linq.Table<food> foods
		{
			get
			{
				return this.GetTable<food>();
			}
		}
		
		public System.Data.Linq.Table<Room> Rooms
		{
			get
			{
				return this.GetTable<Room>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.account")]
	public partial class account : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _displayName;
		
		private string _userName;
		
		private string _password;
		
		private int _type;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OndisplayNameChanging(string value);
    partial void OndisplayNameChanged();
    partial void OnuserNameChanging(string value);
    partial void OnuserNameChanged();
    partial void OnpasswordChanging(string value);
    partial void OnpasswordChanged();
    partial void OntypeChanging(int value);
    partial void OntypeChanged();
    #endregion
		
		public account()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_displayName", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string displayName
		{
			get
			{
				return this._displayName;
			}
			set
			{
				if ((this._displayName != value))
				{
					this.OndisplayNameChanging(value);
					this.SendPropertyChanging();
					this._displayName = value;
					this.SendPropertyChanged("displayName");
					this.OndisplayNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_userName", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string userName
		{
			get
			{
				return this._userName;
			}
			set
			{
				if ((this._userName != value))
				{
					this.OnuserNameChanging(value);
					this.SendPropertyChanging();
					this._userName = value;
					this.SendPropertyChanged("userName");
					this.OnuserNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_password", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string password
		{
			get
			{
				return this._password;
			}
			set
			{
				if ((this._password != value))
				{
					this.OnpasswordChanging(value);
					this.SendPropertyChanging();
					this._password = value;
					this.SendPropertyChanged("password");
					this.OnpasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_type", DbType="Int NOT NULL")]
		public int type
		{
			get
			{
				return this._type;
			}
			set
			{
				if ((this._type != value))
				{
					this.OntypeChanging(value);
					this.SendPropertyChanging();
					this._type = value;
					this.SendPropertyChanged("type");
					this.OntypeChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.bill")]
	public partial class bill : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private int _idRoom;
		
		private System.DateTime _dateCheckIn;
		
		private System.Nullable<System.DateTime> _dateCheckOut;
		
		private System.Nullable<double> _totalPrice;
		
		private int _discount;
		
		private int _status;
		
		private EntitySet<billInfo> _billInfos;
		
		private EntityRef<Room> _Room;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnidRoomChanging(int value);
    partial void OnidRoomChanged();
    partial void OndateCheckInChanging(System.DateTime value);
    partial void OndateCheckInChanged();
    partial void OndateCheckOutChanging(System.Nullable<System.DateTime> value);
    partial void OndateCheckOutChanged();
    partial void OntotalPriceChanging(System.Nullable<double> value);
    partial void OntotalPriceChanged();
    partial void OndiscountChanging(int value);
    partial void OndiscountChanged();
    partial void OnstatusChanging(int value);
    partial void OnstatusChanged();
    #endregion
		
		public bill()
		{
			this._billInfos = new EntitySet<billInfo>(new Action<billInfo>(this.attach_billInfos), new Action<billInfo>(this.detach_billInfos));
			this._Room = default(EntityRef<Room>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idRoom", DbType="Int NOT NULL")]
		public int idRoom
		{
			get
			{
				return this._idRoom;
			}
			set
			{
				if ((this._idRoom != value))
				{
					if (this._Room.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnidRoomChanging(value);
					this.SendPropertyChanging();
					this._idRoom = value;
					this.SendPropertyChanged("idRoom");
					this.OnidRoomChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_dateCheckIn", DbType="DateTime NOT NULL")]
		public System.DateTime dateCheckIn
		{
			get
			{
				return this._dateCheckIn;
			}
			set
			{
				if ((this._dateCheckIn != value))
				{
					this.OndateCheckInChanging(value);
					this.SendPropertyChanging();
					this._dateCheckIn = value;
					this.SendPropertyChanged("dateCheckIn");
					this.OndateCheckInChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_dateCheckOut", DbType="DateTime")]
		public System.Nullable<System.DateTime> dateCheckOut
		{
			get
			{
				return this._dateCheckOut;
			}
			set
			{
				if ((this._dateCheckOut != value))
				{
					this.OndateCheckOutChanging(value);
					this.SendPropertyChanging();
					this._dateCheckOut = value;
					this.SendPropertyChanged("dateCheckOut");
					this.OndateCheckOutChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_totalPrice", DbType="Float")]
		public System.Nullable<double> totalPrice
		{
			get
			{
				return this._totalPrice;
			}
			set
			{
				if ((this._totalPrice != value))
				{
					this.OntotalPriceChanging(value);
					this.SendPropertyChanging();
					this._totalPrice = value;
					this.SendPropertyChanged("totalPrice");
					this.OntotalPriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_discount", DbType="Int NOT NULL")]
		public int discount
		{
			get
			{
				return this._discount;
			}
			set
			{
				if ((this._discount != value))
				{
					this.OndiscountChanging(value);
					this.SendPropertyChanging();
					this._discount = value;
					this.SendPropertyChanged("discount");
					this.OndiscountChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_status", DbType="Int NOT NULL")]
		public int status
		{
			get
			{
				return this._status;
			}
			set
			{
				if ((this._status != value))
				{
					this.OnstatusChanging(value);
					this.SendPropertyChanging();
					this._status = value;
					this.SendPropertyChanged("status");
					this.OnstatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="bill_billInfo", Storage="_billInfos", ThisKey="id", OtherKey="idBill")]
		public EntitySet<billInfo> billInfos
		{
			get
			{
				return this._billInfos;
			}
			set
			{
				this._billInfos.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Room_bill", Storage="_Room", ThisKey="idRoom", OtherKey="id", IsForeignKey=true)]
		public Room Room
		{
			get
			{
				return this._Room.Entity;
			}
			set
			{
				Room previousValue = this._Room.Entity;
				if (((previousValue != value) 
							|| (this._Room.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Room.Entity = null;
						previousValue.bills.Remove(this);
					}
					this._Room.Entity = value;
					if ((value != null))
					{
						value.bills.Add(this);
						this._idRoom = value.id;
					}
					else
					{
						this._idRoom = default(int);
					}
					this.SendPropertyChanged("Room");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_billInfos(billInfo entity)
		{
			this.SendPropertyChanging();
			entity.bill = this;
		}
		
		private void detach_billInfos(billInfo entity)
		{
			this.SendPropertyChanging();
			entity.bill = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.billInfo")]
	public partial class billInfo : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private int _idBill;
		
		private int _idFood;
		
		private int _count;
		
		private EntityRef<bill> _bill;
		
		private EntityRef<food> _food;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnidBillChanging(int value);
    partial void OnidBillChanged();
    partial void OnidFoodChanging(int value);
    partial void OnidFoodChanged();
    partial void OncountChanging(int value);
    partial void OncountChanged();
    #endregion
		
		public billInfo()
		{
			this._bill = default(EntityRef<bill>);
			this._food = default(EntityRef<food>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idBill", DbType="Int NOT NULL")]
		public int idBill
		{
			get
			{
				return this._idBill;
			}
			set
			{
				if ((this._idBill != value))
				{
					if (this._bill.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnidBillChanging(value);
					this.SendPropertyChanging();
					this._idBill = value;
					this.SendPropertyChanged("idBill");
					this.OnidBillChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idFood", DbType="Int NOT NULL")]
		public int idFood
		{
			get
			{
				return this._idFood;
			}
			set
			{
				if ((this._idFood != value))
				{
					if (this._food.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnidFoodChanging(value);
					this.SendPropertyChanging();
					this._idFood = value;
					this.SendPropertyChanged("idFood");
					this.OnidFoodChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_count", DbType="Int NOT NULL")]
		public int count
		{
			get
			{
				return this._count;
			}
			set
			{
				if ((this._count != value))
				{
					this.OncountChanging(value);
					this.SendPropertyChanging();
					this._count = value;
					this.SendPropertyChanged("count");
					this.OncountChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="bill_billInfo", Storage="_bill", ThisKey="idBill", OtherKey="id", IsForeignKey=true)]
		public bill bill
		{
			get
			{
				return this._bill.Entity;
			}
			set
			{
				bill previousValue = this._bill.Entity;
				if (((previousValue != value) 
							|| (this._bill.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._bill.Entity = null;
						previousValue.billInfos.Remove(this);
					}
					this._bill.Entity = value;
					if ((value != null))
					{
						value.billInfos.Add(this);
						this._idBill = value.id;
					}
					else
					{
						this._idBill = default(int);
					}
					this.SendPropertyChanged("bill");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="food_billInfo", Storage="_food", ThisKey="idFood", OtherKey="id", IsForeignKey=true)]
		public food food
		{
			get
			{
				return this._food.Entity;
			}
			set
			{
				food previousValue = this._food.Entity;
				if (((previousValue != value) 
							|| (this._food.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._food.Entity = null;
						previousValue.billInfos.Remove(this);
					}
					this._food.Entity = value;
					if ((value != null))
					{
						value.billInfos.Add(this);
						this._idFood = value.id;
					}
					else
					{
						this._idFood = default(int);
					}
					this.SendPropertyChanged("food");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.foodCategory")]
	public partial class foodCategory : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _Name;
		
		private int _isDelete;
		
		private EntitySet<food> _foods;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnisDeleteChanging(int value);
    partial void OnisDeleteChanged();
    #endregion
		
		public foodCategory()
		{
			this._foods = new EntitySet<food>(new Action<food>(this.attach_foods), new Action<food>(this.detach_foods));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(100)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_isDelete", DbType="Int NOT NULL")]
		public int isDelete
		{
			get
			{
				return this._isDelete;
			}
			set
			{
				if ((this._isDelete != value))
				{
					this.OnisDeleteChanging(value);
					this.SendPropertyChanging();
					this._isDelete = value;
					this.SendPropertyChanged("isDelete");
					this.OnisDeleteChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="foodCategory_food", Storage="_foods", ThisKey="id", OtherKey="idCategory")]
		public EntitySet<food> foods
		{
			get
			{
				return this._foods;
			}
			set
			{
				this._foods.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_foods(food entity)
		{
			this.SendPropertyChanging();
			entity.foodCategory = this;
		}
		
		private void detach_foods(food entity)
		{
			this.SendPropertyChanging();
			entity.foodCategory = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.food")]
	public partial class food : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _Name;
		
		private int _idCategory;
		
		private double _price;
		
		private int _isDelete;
		
		private EntitySet<billInfo> _billInfos;
		
		private EntityRef<foodCategory> _foodCategory;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnidCategoryChanging(int value);
    partial void OnidCategoryChanged();
    partial void OnpriceChanging(double value);
    partial void OnpriceChanged();
    partial void OnisDeleteChanging(int value);
    partial void OnisDeleteChanged();
    #endregion
		
		public food()
		{
			this._billInfos = new EntitySet<billInfo>(new Action<billInfo>(this.attach_billInfos), new Action<billInfo>(this.detach_billInfos));
			this._foodCategory = default(EntityRef<foodCategory>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idCategory", DbType="Int NOT NULL")]
		public int idCategory
		{
			get
			{
				return this._idCategory;
			}
			set
			{
				if ((this._idCategory != value))
				{
					if (this._foodCategory.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnidCategoryChanging(value);
					this.SendPropertyChanging();
					this._idCategory = value;
					this.SendPropertyChanged("idCategory");
					this.OnidCategoryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_price", DbType="Float NOT NULL")]
		public double price
		{
			get
			{
				return this._price;
			}
			set
			{
				if ((this._price != value))
				{
					this.OnpriceChanging(value);
					this.SendPropertyChanging();
					this._price = value;
					this.SendPropertyChanged("price");
					this.OnpriceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_isDelete", DbType="Int NOT NULL")]
		public int isDelete
		{
			get
			{
				return this._isDelete;
			}
			set
			{
				if ((this._isDelete != value))
				{
					this.OnisDeleteChanging(value);
					this.SendPropertyChanging();
					this._isDelete = value;
					this.SendPropertyChanged("isDelete");
					this.OnisDeleteChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="food_billInfo", Storage="_billInfos", ThisKey="id", OtherKey="idFood")]
		public EntitySet<billInfo> billInfos
		{
			get
			{
				return this._billInfos;
			}
			set
			{
				this._billInfos.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="foodCategory_food", Storage="_foodCategory", ThisKey="idCategory", OtherKey="id", IsForeignKey=true)]
		public foodCategory foodCategory
		{
			get
			{
				return this._foodCategory.Entity;
			}
			set
			{
				foodCategory previousValue = this._foodCategory.Entity;
				if (((previousValue != value) 
							|| (this._foodCategory.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._foodCategory.Entity = null;
						previousValue.foods.Remove(this);
					}
					this._foodCategory.Entity = value;
					if ((value != null))
					{
						value.foods.Add(this);
						this._idCategory = value.id;
					}
					else
					{
						this._idCategory = default(int);
					}
					this.SendPropertyChanged("foodCategory");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_billInfos(billInfo entity)
		{
			this.SendPropertyChanging();
			entity.food = this;
		}
		
		private void detach_billInfos(billInfo entity)
		{
			this.SendPropertyChanging();
			entity.food = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Room")]
	public partial class Room : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _Name;
		
		private string _status;
		
		private int _isDelete;
		
		private EntitySet<bill> _bills;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnstatusChanging(string value);
    partial void OnstatusChanged();
    partial void OnisDeleteChanging(int value);
    partial void OnisDeleteChanged();
    #endregion
		
		public Room()
		{
			this._bills = new EntitySet<bill>(new Action<bill>(this.attach_bills), new Action<bill>(this.detach_bills));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_status", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string status
		{
			get
			{
				return this._status;
			}
			set
			{
				if ((this._status != value))
				{
					this.OnstatusChanging(value);
					this.SendPropertyChanging();
					this._status = value;
					this.SendPropertyChanged("status");
					this.OnstatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_isDelete", DbType="Int NOT NULL")]
		public int isDelete
		{
			get
			{
				return this._isDelete;
			}
			set
			{
				if ((this._isDelete != value))
				{
					this.OnisDeleteChanging(value);
					this.SendPropertyChanging();
					this._isDelete = value;
					this.SendPropertyChanged("isDelete");
					this.OnisDeleteChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Room_bill", Storage="_bills", ThisKey="id", OtherKey="idRoom")]
		public EntitySet<bill> bills
		{
			get
			{
				return this._bills;
			}
			set
			{
				this._bills.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_bills(bill entity)
		{
			this.SendPropertyChanging();
			entity.Room = this;
		}
		
		private void detach_bills(bill entity)
		{
			this.SendPropertyChanging();
			entity.Room = null;
		}
	}
}
#pragma warning restore 1591