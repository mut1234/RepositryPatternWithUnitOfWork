﻿namespace RepoPattrenWithUnitOfWork.EF.Triggers
{
    public interface ISoftDeletable
    {
        public bool IsDeleted { get; set; }

        public DateTime? DeletedAt { get; set; }
    }

}
