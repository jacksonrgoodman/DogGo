using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogGo.Models;
using Microsoft.Data.SqlClient;

namespace DogGo.Repositories
{
    public interface IWalkerRepository
    {
        List<Walker> GetAllWalkers();
        Walker GetWalkerById(int id);
    }
}
