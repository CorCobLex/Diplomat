<template>
  <section>
    <div id="dropdown">
      <b-dropdown aria-role="list">
        <template #trigger="{ active }">
          <b-button
            label="Типы объектов"
            type="is-primary"
            :icon-right="active ? 'menu-up' : 'menu-down'"
          />
        </template>

        <b-dropdown-item aria-role="listitem">Тест</b-dropdown-item>
        <b-dropdown-item aria-role="listitem">Тест</b-dropdown-item>
        <b-dropdown-item aria-role="listitem">Тест</b-dropdown-item>
      </b-dropdown>
      <b-dropdown aria-role="list">
        <template #trigger="{ active }">
          <b-button
            label="Параметры"
            type="is-primary"
            :icon-right="active ? 'menu-up' : 'menu-down'"
          />
        </template>

        <b-dropdown-item aria-role="listitem">Тест</b-dropdown-item>
        <b-dropdown-item aria-role="listitem">Тест</b-dropdown-item>
        <b-dropdown-item aria-role="listitem">Тест</b-dropdown-item>
      </b-dropdown>
      <b-dropdown aria-role="list">
        <template #trigger="{ active }">
          <b-button
            label="Экземпляры"
            type="is-primary"
            :icon-right="active ? 'menu-up' : 'menu-down'"
          />
        </template>

        <b-dropdown-item aria-role="listitem">Тест</b-dropdown-item>
        <b-dropdown-item aria-role="listitem">Тест</b-dropdown-item>
        <b-dropdown-item aria-role="listitem">Тест</b-dropdown-item>
      </b-dropdown>

      <b-button>1М</b-button>
      <b-button>10М</b-button>
      <b-button>1Ч</b-button>
      <b-button>1Д</b-button>
    </div>
  </section>
</template>
<script>
export default {
  data() {
    return {
      toggle_exclusive: undefined,
    };
  },
};
</script>

<style>
* {
  overflow-y: hidden;
}
</style>
