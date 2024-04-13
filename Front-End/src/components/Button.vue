<template>
    <button class="button" @click="$emit('click')">
        <slot></slot>
    </button>
</template>

<style scoped>
.button {
    margin-right: 2em;
    margin-top: 1em;
    font-size: 15px;
    background-color: #9758a6;
    width: 100%;
    color: white;
    border: none;
    border-radius: 5px;
    padding: 15px;
    cursor: pointer;
}

.button:hover {
    background-color: #8c4d9f;
}
</style>