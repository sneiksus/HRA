import App from './App.svelte';
import Play from './Play.svelte';
import Index from './Index.svelte';
import Lobby from './Lobby.svelte';

const app = new Lobby({
	target: document.body
});

export default app;