namespace Controllers
{
    public interface IObjectSpawnerController
    {
        void RelocateObjectSpawnPosition(string objectId,float posX,float posY,float posZ);
    }
}