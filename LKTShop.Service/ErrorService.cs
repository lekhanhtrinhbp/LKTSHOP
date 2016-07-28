using LKTShop.Data.Infrastructure;
using LKTShop.Data.Repositories;
using LKTShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LKTShop.Service
{
    public interface IErrorService
    {
        Error Add(Error Error);
        void Save();
        Error Delete(int id);
        IEnumerable<Error> GetAll();
        Error GetById(int id);
    }
    public class ErrorService : IErrorService
    {
        IErrorRepository _errorRepository;
        IUnitOfWork _unitOfWork;

        public ErrorService(IErrorRepository ErrorRepository, IUnitOfWork unitOfWork)
        {
            this._errorRepository = ErrorRepository;
            this._unitOfWork = unitOfWork;
        }
        public Error Add(Error Error)
        {
            return this._errorRepository.Add(Error);
        }

        public Error Delete(int id)
        {
            return this._errorRepository.Delete(id);
        }

        public IEnumerable<Error> GetAll()
        {
            return this._errorRepository.GetAll();
        }

        public Error GetById(int id)
        {
            return this._errorRepository.GetSingleById(id);
        }

        public void Save()
        {
            this._unitOfWork.Commit();
        }
    }
}
