using Infrastructure.Utils;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Infrastructure.Repository
{
    public class RepositoryPlanCobro : IRepositoryPlanCobro
    {
        public IEnumerable<PlanCobro> GetPlanesCobro()
        {
            try
            {
                IEnumerable<PlanCobro> list = null;
                using (DatabaseContext cx = new DatabaseContext())
                {
                    cx.Configuration.LazyLoadingEnabled = false;
                    list = cx.PlanCobro.Include("Rubro").ToList();
                }
                return list;
            }
            catch (DbUpdateException dbEx)
            {
                string mensaje = "Error en la conexión a la base de datos";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "Error desconocido";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw ex;
            }
        }

        public PlanCobro GetPlanCobroByID(int id)
        {
            try
            {
                PlanCobro planCobro = null;
                using (DatabaseContext cx = new DatabaseContext())
                {
                    cx.Configuration.LazyLoadingEnabled = false;
                    planCobro = cx.PlanCobro.Include("Rubro").Where(plan => plan.ID == id).FirstOrDefault();
                }
                return planCobro;
            }
            catch (DbUpdateException dbEx)
            {
                string mensaje = "";
                Log.Error(dbEx, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw new Exception(mensaje);
            }
            catch (Exception ex)
            {
                string mensaje = "";
                Log.Error(ex, System.Reflection.MethodBase.GetCurrentMethod(), ref mensaje);
                throw;
            }
        }

        public PlanCobro Save(PlanCobro plan, int[] rubros)
        {
            int retorno = 0;
            PlanCobro oPlanCobro = null;

            using (DatabaseContext ctx = new DatabaseContext())
            {
                ctx.Configuration.LazyLoadingEnabled = false;
                oPlanCobro = GetPlanCobroByID(plan.ID);
                IRepositoryRubro _RepositoryRubro = new RepositoryRubro();
                if (oPlanCobro == null)
                {
                    if (rubros != null)
                    {
                        plan.Rubro = new List<Rubro>();
                        foreach (int rubroId in rubros)
                        {
                            var rubroToAdd = _RepositoryRubro.GetRubroByID(rubroId);
                            ctx.Rubro.Attach(rubroToAdd);
                            plan.Rubro.Add(rubroToAdd);
                        }
                    }
                    ctx.PlanCobro.Add(plan);
                    retorno = ctx.SaveChanges();
                }
                else
                {
                    ctx.PlanCobro.Add(plan);
                    ctx.Entry(plan).State = EntityState.Modified;
                    retorno = ctx.SaveChanges();
                    if (rubros != null)
                    {
                        ctx.Entry(plan).Collection(p => p.Rubro).Load();
                        var newRubroForPlanCobro = ctx.Rubro.Where(rubro => rubros.Contains(rubro.ID)).ToList();
                        plan.Rubro = newRubroForPlanCobro;
                        ctx.Entry(plan).State = EntityState.Modified;
                        retorno = ctx.SaveChanges();
                    }
                }
            }
            if (retorno >= 0)
                oPlanCobro = GetPlanCobroByID(plan.ID);
            return oPlanCobro;
        }
    }
}
