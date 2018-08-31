using OPIM_Common.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using ECommon.Dapper;

namespace OPIM_Dapper.Dappers
{
    public class MemberShipDapper : DbConnectionSetting
    {
        /// <summary>
        /// 创建新的用户
        /// </summary>
        /// <param name="model"></param>
        public Results Create(MemberShipsModel model)
        {
            using (var connection = GetConnection())
            {
                try
                { 
                    connection.Open();
                    var result = connection.Insert(new
                    {
                        Id = model.Id,
                        Account = model.Account,
                        Password = model.Password,
                        CreateOn = model.CreateOn,
                        LimitLevel = model.LimitLevel,
                        NickName = model.NickName,
                        //Sex = model.Sex,
                        //BirthOn = model.BirthOn,
                        //Icon = model.Icon
                    }, OPIM_Common.TableName.MemberShips);
                    return new Results();
                }
                catch (Exception ex)
                {
                    return new Results(ex.Message);
                }
            }
        }
        /// <summary>
        /// 根据Id删除用户
        /// </summary>
        /// <param name="id"></param>
        public Results Delete(Guid id)
        {
            using (var connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    var result = connection.DeleteAsync(new
                    {
                        Id = id
                    }, OPIM_Common.TableName.MemberShips);
                    return new Results();
                }
                catch (Exception ex)
                {
                    return new Results(ex.Message);
                }
            }
        }
        /// <summary>
        /// 查询所有的用户
        /// </summary>
        public IEnumerable<MemberShipsModel> QueryList()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var result = connection.QueryList<MemberShipsModel>(new { }, OPIM_Common.TableName.MemberShips).ToList();
                return result;
            }
        }
        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="model"></param>
        public Results Update(MemberShipsModel model)
        {
            using (var connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    var result = connection.Update(new
                    {
                        NickName = model.NickName,
                        Sex = model.Sex,
                        BirthOn = model.BirthOn,
                        Email = model.Email,
                        Phone = model.Phone
                    }, new
                    {
                        Id = model.Id
                    }, OPIM_Common.TableName.MemberShips);
                    return new Results();
                }
                catch (Exception ex)
                {
                    return new Results(ex.Message);
                }
            }
        }
        public Results UpdatePassword(Guid id, string password)
        {
            using (var connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    var result = connection.Update(new
                    {
                        Password = password
                    }, new
                    {
                        Id = id
                    }, OPIM_Common.TableName.MemberShips);
                    return new Results();
                }
                catch (Exception ex)
                {
                    return new Results(ex.Message);
                }
            }
        }
        public Results UpdateIcon(Guid id, string path)
        {
            using (var connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    var result = connection.Update(new
                    {
                        Icon = path
                    }, new
                    {
                        Id = id
                    }, OPIM_Common.TableName.MemberShips);
                    return new Results();
                }
                catch (Exception ex)
                {
                    return new Results(ex.Message);
                }
            }
        }
        public MemberShipsModel GetMemberShipByAccount(string account)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var result = connection.QueryList<MemberShipsModel>(new { Account = account }, OPIM_Common.TableName.MemberShips).FirstOrDefault();
                return result;
            }
        }

        public MemberShipsModel GetMemberShipById(Guid id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var result = connection.QueryList<MemberShipsModel>(new { Id = id }, OPIM_Common.TableName.MemberShips).FirstOrDefault();
                return result;
            }
        }
    }
}
