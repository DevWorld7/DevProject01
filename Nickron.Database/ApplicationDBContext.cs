using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data;

namespace Nickron.Database
{
    public class ApplicationDBContext : NikcronModelContainer
    {
        public UserSession Session { get; set; }
        public string Property { get; set; }

        public ApplicationDBContext()
        {
            Session = new UserSession();
        }

        public ApplicationDBContext(UserSession _Session)
        {
            Session = _Session;
        }

        public override int SaveChanges(System.Data.Objects.SaveOptions options)
        {
            DetectChanges();

            #region Creation
            var addedEntities = ObjectStateManager.GetObjectStateEntries(EntityState.Added);

            foreach (var addEntity in addedEntities)
            {

                if (addEntity != null)
                {
                    if (addEntity.Entity != null)
                    {
                        PropertyInfo auditProperty = addEntity.Entity.GetType().GetProperty("AuditLog");
                        if (auditProperty != null)
                        {
                            AuditLog auditLog = (AuditLog)addEntity.Entity.GetType().GetProperty("AuditLog").GetValue(addEntity.Entity, null);
                            auditLog.ModifiedOn = System.DateTime.Now;
                            auditLog.ModifiedBy = Session.UserId;
                            addEntity.Entity.GetType().GetProperty("AuditLog").SetValue(addEntity.Entity, auditLog, null);
                        }
                    }
                }
            }
            #endregion

            #region Modification

            var modifiedEntities = ObjectStateManager.GetObjectStateEntries(EntityState.Modified);

            foreach (var modifiedentity in modifiedEntities)
            {

                if (modifiedentity != null)
                {
                    if (modifiedentity.Entity != null)
                    {
                        PropertyInfo auditProperty = modifiedentity.Entity.GetType().GetProperty("AuditLog");
                        if (auditProperty != null)
                        {
                            AuditLog auditLog = (AuditLog)modifiedentity.Entity.GetType().GetProperty("AuditLog").GetValue(modifiedentity.Entity, null);
                            auditLog.ModifiedOn = System.DateTime.Now;
                            auditLog.ModifiedBy = Session.UserId;
                            modifiedentity.Entity.GetType().GetProperty("AuditLog").SetValue(modifiedentity.Entity, auditLog, null);
                        }
                    }
                }
            }
            #endregion

            #region Deletion
            var deletedEntities = ObjectStateManager.GetObjectStateEntries(EntityState.Deleted);
            foreach (var deleteEntity in deletedEntities)
            {
                if (deleteEntity != null)
                {
                    if (deleteEntity.Entity != null)
                    {
                        PropertyInfo auditProperty = deleteEntity.Entity.GetType().GetProperty("AuditLog");
                        if (auditProperty != null)
                        {
                            AuditLog auditLog = (AuditLog)deleteEntity.Entity.GetType().GetProperty("AuditLog").GetValue(deleteEntity.Entity, null);
                            auditLog.ModifiedOn = System.DateTime.Now;
                            auditLog.ModifiedBy = Session.UserId;
                            deleteEntity.Entity.GetType().GetProperty("AuditLog").SetValue(deleteEntity.Entity, auditLog, null);
                        }
                        PropertyInfo statusProperty = deleteEntity.Entity.GetType().GetProperty("Status");
                        if (statusProperty != null)
                        {
                            Status status = (Status)deleteEntity.Entity.GetType().GetProperty("Status").GetValue(deleteEntity, null);
                            status.IsDeleted = true;
                        }
                        deleteEntity.ChangeState(EntityState.Modified);
                    }
                }
            }
            #endregion

            return base.SaveChanges(options);
        }
    }
}
