using Data.Context;
using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class UnitOfWork : IDisposable
    {
        private readonly SportsEventsManagerDBContext context;
        private GenericRepository<Organisation> organisationRepository;
        private GenericRepository<Event> eventRepository;
        private GenericRepository<User> userRepository;

        public UnitOfWork()
        {
            this.context = new SportsEventsManagerDBContext();
        }

        public GenericRepository<Organisation> OrganisationRepository
        {
            get
            {

                if (this.organisationRepository == null)
                {
                    this.organisationRepository = new GenericRepository<Organisation>(context);
                }
                return organisationRepository;
            }
        }

        public GenericRepository<Event> EventRepository
        {
            get
            {

                if (this.eventRepository == null)
                {
                    this.eventRepository = new GenericRepository<Event>(context);
                }
                return eventRepository;
            }
        }
        public GenericRepository<User> UserRepository
        {
            get
            {

                if (this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<User>(context);
                }
                return userRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
