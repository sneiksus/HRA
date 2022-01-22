<script>
    import Card from "./Card.svelte";
    import Player from "./Player.svelte";
	import Chat from "./Chat.svelte";
	import Timer from "./Timer.svelte";
	import Info from "./Info.svelte";
	import { Router } from 'svelte-router-spa'
    import Lobby from "./Lobby.svelte";
	import Index from "./Index.svelte";
  import Play from "./Play.svelte";
	const routes = [
  {
    name: '/',
    component: Index,
  },
  {
    name: '/lobby',
    component: Lobby,
  },
  {
    name: '/play',
    component: Play,
  }
  ];
</script>

<main>
	<Router {routes} />
	
</main>

