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
        List<Walker> GetWalkersInNeighborhood(int neighborhoodId);
        void AddWalker(Walker walker);
        void UpdateWalker(Walker walker);
        void DeleteWalker(int walkerId);
    }
}
