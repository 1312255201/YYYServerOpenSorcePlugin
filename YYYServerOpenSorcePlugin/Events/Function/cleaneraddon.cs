using Exiled.API.Enums;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.API.Features.Pickups;
using Exiled.Events.EventArgs.Server;
using InventorySystem.Items.Pickups;
using MEC;
using Mirror;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace YYYServerOpenSorcePlugin.Events.Function
{
    public class cleaneraddon
    {
        public static List<ushort> Roundstartthing = new List<ushort>();
        public static List<CoroutineHandle> Coroutines = new List<CoroutineHandle>();
        private static void OnRoundStart()
        {
            ItemPickupBase[] array2 = UnityEngine.Object.FindObjectsOfType<ItemPickupBase>();
            foreach (ItemPickupBase item in array2)
            {
                if (!Roundstartthing.Contains(item.Info.Serial))
                {
                    Roundstartthing.Add(item.Info.Serial);
                    Log.Info(item.Info.Serial);
                }
            }
            Log.Info("-------------");
            foreach (Pickup item in Pickup.List)
            {
                if(!Roundstartthing.Contains(item.Serial))
                {
                    Roundstartthing.Add(item.Serial);
                    Log.Info(item.Serial);
                }
            }
            Coroutines.Add(Timing.RunCoroutine(CleanFuc()));
        }
        private static IEnumerator<float> CleanFuc()
        {
            yield return Timing.WaitForSeconds(1f);
            while (Round.IsStarted)
            {
                Exiled.API.Features.Map.Broadcast(5, "<color=#FFFF00>[小鱼服务器清理大师]</color>\n<color=#66FFFF>哇你们白给了好多垃圾成堆了呀</color>\n我会在<color=#FF0000>400s</color>后清理服务器", Broadcast.BroadcastFlags.Normal, false);
                yield return Timing.WaitForSeconds(200f);
                Exiled.API.Features.Map.Broadcast(5, "<color=#FFFF00>[小鱼服务器清理大师]</color>\n<color=#66FFFF>哇你们白给了好多垃圾成堆了呀</color>\n我会在<color=#FF0000>200s</color>后清理服务器", Broadcast.BroadcastFlags.Normal, false);
                yield return Timing.WaitForSeconds(150f);
                Exiled.API.Features.Map.Broadcast(5, "<color=#FFFF00>[小鱼服务器清理大师]</color>\n<color=#66FFFF>哇你们白给了好多垃圾成堆了呀</color>\n我会在<color=#FF0000>50f</color>后清理服务器", Broadcast.BroadcastFlags.Normal, false);
                yield return Timing.WaitForSeconds(40f);
                Map.ClearBroadcasts();
                Exiled.API.Features.Map.Broadcast(5, "<color=#FFFF00>[小鱼服务器清理大师]</color>\n<color=#66FFFF>哇你们白给了好多垃圾成堆了呀</color>\n我会在<color=#FF0000>10s</color>后清理服务器", Broadcast.BroadcastFlags.Normal, false);
                Exiled.API.Features.Map.Broadcast(1, "<color=#FFFF00>[小鱼服务器清理大师]</color>\n<color=#66FFFF>哇你们白给了好多垃圾成堆了呀</color>\n我会在<color=#FF0000>5s</color>后清理服务器", Broadcast.BroadcastFlags.Normal, false);
                Exiled.API.Features.Map.Broadcast(1, "<color=#FFFF00>[小鱼服务器清理大师]</color>\n<color=#66FFFF>哇你们白给了好多垃圾成堆了呀</color>\n我会在<color=#FF0000>4s</color>后清理服务器", Broadcast.BroadcastFlags.Normal, false);
                Exiled.API.Features.Map.Broadcast(1, "<color=#FFFF00>[小鱼服务器清理大师]</color>\n<color=#66FFFF>哇你们白给了好多垃圾成堆了呀</color>\n我会在<color=#FF0000>3s</color>后清理服务器", Broadcast.BroadcastFlags.Normal, false);
                Exiled.API.Features.Map.Broadcast(1, "<color=#FFFF00>[小鱼服务器清理大师]</color>\n<color=#66FFFF>哇你们白给了好多垃圾成堆了呀</color>\n我会在<color=#FF0000>2s</color>后清理服务器", Broadcast.BroadcastFlags.Normal, false);
                Exiled.API.Features.Map.Broadcast(1, "<color=#FFFF00>[小鱼服务器清理大师]</color>\n<color=#66FFFF>哇你们白给了好多垃圾成堆了呀</color>\n我会在<color=#FF0000>1s</color>后清理服务器", Broadcast.BroadcastFlags.Normal, false);
                Exiled.API.Features.Map.Broadcast(4, "<color=#FFFF00>[小鱼服务器清理大师]</color>\n<color=#66FFFF>开始清理</color>", Broadcast.BroadcastFlags.Normal, false);
                yield return Timing.WaitForSeconds(15f);
                int itemtime = 0;
                int ragdolltime = 0;
                ItemPickupBase[] array2 = UnityEngine.Object.FindObjectsOfType<ItemPickupBase>();
                foreach (ItemPickupBase item in array2)
                {
                    if (!Roundstartthing.Contains(item.Info.Serial) && !item.Info.ItemId.IsScp() && !item.Info.ItemId.IsKeycard() && item.Info.Serial!= 0)
                    {
                        bool flag = false;
                        try
                        {
                            if (Room.Get(item.Info.Position).Type == RoomType.Lcz914)
                            {
                                flag = true;
                            }
                        }
                        catch
                        {
                        }
                        if (flag == true)
                        {
                            continue;
                        }
                        NetworkServer.Destroy(item.gameObject);
                        itemtime++;
                    }
                }
                BasicRagdoll[] array = UnityEngine.Object.FindObjectsOfType<BasicRagdoll>();
                foreach (BasicRagdoll ragdoll in array)
                {
                    NetworkServer.Destroy(ragdoll.gameObject);
                    ragdolltime++;
                }
                Map.ClearBroadcasts();
                Exiled.API.Features.Map.Broadcast(4, "<color=#FFFF00>[小鱼服务器清理大师]</color>\n<color=#66FFFF>好饱呀</color>\n本次清理了" + itemtime + "个物品" + ragdolltime + "个尸体", Broadcast.BroadcastFlags.Normal, false);
                ragdolltime = 0;
                itemtime = 0;
            }
        }
        private static void OnRoundEnded(RoundEndedEventArgs ev)
        {
            foreach (CoroutineHandle coroutineHandle in Coroutines)
            {
                Timing.KillCoroutines(coroutineHandle);
            }
            Coroutines.Clear();
        }

        public static void Reg()
        {
            Exiled.Events.Handlers.Server.RoundStarted += OnRoundStart;
            Exiled.Events.Handlers.Server.RoundEnded += OnRoundEnded;
        }
        public static void UnReg()
        {
            Exiled.Events.Handlers.Server.RoundStarted += OnRoundStart;
            Exiled.Events.Handlers.Server.RoundEnded += OnRoundEnded;
        }
    }

}
