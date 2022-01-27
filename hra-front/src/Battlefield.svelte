<script>
    import Card from "./Card.svelte";

    export let attack=null;
    export let defend=null;

    console.log(attack);
</script>

<div id="root">
    <div id="first">
        {#if attack!=null}
            
        <Card xp={attack.points} type={attack.type} />
        {/if}
    </div>
    <i>VS</i>
    <div id="second">
        {#if defend!=null}
            
        <Card xp={defend.points} type={defend.type} />
        {/if}
    </div>
</div>

<style>
    #root {
        padding: 1em;
    }
    i {
        display: inline-block;
        font-family: "Roboto";
        font-style: normal;
        font-weight: 900;
        font-size: 6em;
        line-height: 72px;
        color: white;
        vertical-align: middle;
    }
    #first{
        margin: 0.75em;
        display: inline-block;
        vertical-align: middle;
        height: 11em;
        width: 7em;
        border: 7px dashed  grey;
        border-radius: 15px;
    }
    #second{
         margin: 0.75em;
        display: inline-block;
        vertical-align: middle;
        height: 11em;
        width: 7em;
        border: 7px dashed  grey;
        border-radius: 15px;
    }
</style>
