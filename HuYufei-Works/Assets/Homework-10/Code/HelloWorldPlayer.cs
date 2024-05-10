

namespace Homework_10.Code
{
    using Unity.Netcode;
    using UnityEngine;
    
    public class HelloWorldPlayer : NetworkBehaviour
    {
        public NetworkVariable<Vector3> Position = new NetworkVariable<Vector3>();

        public Renderer _renderer;
        public Material[] _mats;

        public override void OnNetworkSpawn()
        {
            if (IsOwner)
            {
                Move();
            }


            if (IsClient)
            {
                _renderer.material = _mats[1];
            }

            if (IsHost)
            {
                _renderer.material = _mats[0];
            }

        }

        public void Move()
        {
            SubmitPositionRequestServerRpc();
        }

        [Rpc(SendTo.Server)]
        void SubmitPositionRequestServerRpc(RpcParams rpcParams = default)
        {
            var randomPosition = GetRandomPositionOnPlane();
            transform.position = randomPosition;
            Position.Value = randomPosition;
        }

        static Vector3 GetRandomPositionOnPlane()
        {
            return new Vector3(Random.Range(-3f, 3f), 1f, Random.Range(-3f, 3f));
        }

        void Update()
        {
            transform.position = Position.Value;
        }
    }
}