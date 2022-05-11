using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Items
{
    public class Weapon : BaseItem
    {
        public WeaponData weaponData;

        public Transform MuzzleTransform;

        private bool isShooting = false;
        private float nextShootTime = 0;
        private Vector3 target = Vector3.zero;

        public void SetTarget(Vector3 target) => this.target = target;

        public void UpdateWeapon()
        {
            if (isShooting)
            {
                nextShootTime -= 1 * Time.deltaTime;
                if (nextShootTime <= 0)
                {
                    //Shoot
                    ShotProcess();
                    nextShootTime = weaponData.FireRate;
                }
            }
            else
            {
                if (nextShootTime > 0)
                {
                    nextShootTime -= 1 * Time.deltaTime;
                }
            }
        }

        //All available weapon actions
        public void StartShoot(Vector3 target)
        {
            isShooting = true;
            this.target = target;
        }

        public void StopShoot()
        {
            isShooting = false;
        }

        public void Reloading()
        {

        }

        public void Take()
        {

        }

        public void Drop()
        {

        }

        private void ShotProcess()
        {
            Vector3 finalPos = Random.insideUnitSphere * Vector3.Distance(MuzzleTransform.position, target) * weaponData.BaseScattering + target;

            RaycastHit2D hitFP = Physics2D.Linecast(MuzzleTransform.position, finalPos);

            SpawnTracer(finalPos);
        }

        private void SpawnTracer(Vector3 targetPos)
        {
            int randIndex = Random.Range(0, weaponData.TracersData.tracers.Count);
            GameObject tracer = Instantiate(weaponData.TracersData.tracers[randIndex]);
            tracer.transform.position = MuzzleTransform.position;
            tracer.GetComponent<Tracer>().Target = targetPos;
            Destroy(tracer, 0.5f);
        }
    }
}
