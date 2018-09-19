using App;

public class UnlockingSystem
{
   public void TryToUnlock(AppConfigurations app, string password)
   {
      if (app.Password.Equals(password))
      {
         Unlock(app);
      }
   }
   
   public void Unlock(AppConfigurations app)
   {
      app.LockingState = false;
   }
    
}
