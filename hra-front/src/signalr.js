// import * as signalR from "@microsoft/signalr";
//   let hubConnection = new signalR.HubConnectionBuilder()
//             .withUrl("https://localhost:44300/game")
//             .build();
// 			console.log(hubConnection);

//             hubConnection.on("FilledRoom", function (data) {
//                 console.log("fiiled room");
//                 isRoomFull = true;
//                 setTimeout(() => {
//                    isRoomFull = false;
//                 }, 2000);
//            });
//            hubConnection.on("GoInRoom", function (data) {
//                 console.log("GoInRoom");
//                 navigateTo('lobby');
//            });
//            hubConnection.on("NotFoundRoom", function (data) {
//                 console.log("NotFoundRoom");
//                 isCodeWrong = true;
//                 setTimeout(() => {
//                    isCodeWrong = false;
//                 }, 2000);
                
//            });
import * as signalR from "@microsoft/signalr"
import { writable } from "svelte/store";

export const roomCode = writable('nula');
export const HUB = writable('nula');