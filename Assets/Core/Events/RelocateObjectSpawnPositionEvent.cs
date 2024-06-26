namespace Events
{
    public record RelocateObjectSpawnPositionEvent
    {
        public string ObjectId;
        public readonly float PosX;
        public readonly float PosY;
        public readonly float PosZ;

        public RelocateObjectSpawnPositionEvent(string objectId,float posX, float posY, float posZ)
        {
            ObjectId = objectId;
            PosX = posX;
            PosY = posY;
            PosZ = posZ;
        }
    }
}