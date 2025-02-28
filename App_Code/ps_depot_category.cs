﻿using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

	/// <summary>
	/// 地区-类
	/// </summary>
	[Serializable]
	public partial class ps_depot_category
	{
		public ps_depot_category()
		{}
        #region Model
        private int _id;
        private string _title = "";
        private int? _sort_id = 0;
        private string _remark = "";
        private string _name = "";
        /// <summary>
        /// 地区id
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 地区名称
        /// </summary>
        public string title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int? sort_id
        {
            set { _sort_id = value; }
            get { return _sort_id; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string remark
        {
            set { _remark = value; }
            get { return _remark; }
        }

        public string name
        {
            set { _name = value; }
            get { return _name; }
        }

    
    #endregion Model


    #region  Method


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from [ps_depot_category]");
			strSql.Append(" where id=@id ");

			SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
			parameters[0].Value = id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


        /// <summary>
        /// 查询名称是否存在
        /// </summary>
        public bool Exists(string title)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from  ps_depot_category");
            strSql.Append(" where title=@title ");
            SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,100)};
            parameters[0].Value = title;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 查询排除自己名称是否存在
        /// </summary>
        public bool Exists(string title, int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from  ps_depot_category");
            strSql.Append(" where  id<>@id and  title=@title ");
            SqlParameter[] parameters = {
                     new SqlParameter("@id", SqlDbType.Int,4),
					new SqlParameter("@title", SqlDbType.NVarChar,100)};
            parameters[0].Value = id;
            parameters[1].Value = title;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 返回地区名称
        /// </summary>
        public string GetTitle(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 name from [ps_depot_category]");
            strSql.Append(" where id=" + id);
            string name = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(name))
            {
                return "";
            }
            return name;
        }

        /// <summary>
        /// 返回地区名称
        /// </summary>
        public string GetTitle2(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 title from [ps_depot_category]");
            strSql.Append(" where id=" + id);
            string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(title))
            {
                return "";
            }
            return title;
        }

        public string GetCompany(int id)
        {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select top 1 title from [ps_depot_category]");
        strSql.Append(" where id=" + id);
        string title = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
        if (string.IsNullOrEmpty(title))
        {
            return "";
        }
        return title;
    }

    public int GetCompanyIDByCode(string companycode)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select top 1 id from [ps_depot_category]");
        strSql.Append(" where title='" + companycode + "'");
        int id = Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        
        return id;
    }
    /// <summary>
    /// 增加一条数据
    /// </summary>
    public int Add()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into [ps_depot_category] (");
            strSql.Append("title,sort_id,remark)");
            strSql.Append(" values (");
            strSql.Append("@title,@sort_id,@remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.VarChar,50),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,200)};
            parameters[0].Value = title;
            parameters[1].Value = sort_id;
            parameters[2].Value = remark;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update [ps_depot_category] set ");
            strSql.Append("title=@title,");
            strSql.Append("sort_id=@sort_id,");
            strSql.Append("remark=@remark");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.VarChar,50),
					new SqlParameter("@sort_id", SqlDbType.Int,4),
					new SqlParameter("@remark", SqlDbType.VarChar,200),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = title;
            parameters[1].Value = sort_id;
            parameters[2].Value = remark;
            parameters[3].Value = id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from [ps_depot_category] ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public void GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,title,sort_id,remark,name ");
            strSql.Append(" FROM [ps_depot_category] ");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    this.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["title"] != null)
                {
                    this.title = ds.Tables[0].Rows[0]["title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["sort_id"] != null && ds.Tables[0].Rows[0]["sort_id"].ToString() != "")
                {
                    this.sort_id = int.Parse(ds.Tables[0].Rows[0]["sort_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["remark"] != null)
                {
                    this.remark = ds.Tables[0].Rows[0]["remark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["name"] != null)
                {
                    this.name = ds.Tables[0].Rows[0]["name"].ToString();
                }
            }
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ps_depot_category set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }
	
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM [ps_depot_category] ");
			if(strWhere.Trim()!="")
			{
                strSql.Append(" where " + strWhere + " order by sort_id asc,id desc");
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 通过id获得对应的信息
        /// </summary>
        public DataTable GetList(int category_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from ps_depot_category");
            if (category_id == 0)
            {
                strSql.Append(" order by sort_id asc,id desc");
            }
            else
            {
                strSql.Append(" where id=" + category_id + " order by sort_id asc,id desc");
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            return ds.Tables[0];
        }

        public DataTable GetCustomerSupportList(int customer_support_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from ps_customer_support");
            if (customer_support_id == 0)
            {
                strSql.Append(" order by id desc");
            }
            else
            {
                strSql.Append(" where id=" + customer_support_id + " order by id desc");
            }
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            return ds.Tables[0];
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM  ps_depot_category");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM  ps_depot_category");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
	
        #endregion  Method
	}


