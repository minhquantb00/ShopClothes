<template>
  <div class="home-description container-xl">
    <v-container>
      <v-row>
        <v-col v-for="info in information" :key="info.id">
          <div class="description">
            <div class="d-flex">
              <v-btn style="border:none; box-shadow: none;">
                <img :src="info.image"/>
              </v-btn>
              <div >
                <h4>
                  {{ info.title }}
                </h4>
                <p>{{ info.description }}</p>
              </div>
            </div>
          </div>
        </v-col>
      </v-row>
    </v-container>
  </div>
</template>

<script>
export default {
  data() {
    return {
      information: [
        {
          id: 1,
          image: 'https://theme.hstatic.net/1000341902/1001140246/14/policies_icon_1_thumb.png?v=755',
          title: 'Vận chuyển nhanh chóng',
          description: 'Nhận hàng trong vòng 3 ngày'
        },
        {
          id: 2,
          image: 'https://theme.hstatic.net/1000341902/1001140246/14/policies_icon_2_thumb.png?v=755',
          title: 'Nhiều khuyến mãi hấp dẫn',
          description: 'Ưu đãi lên đến 50% - giá chỉ từ 89k'
        },
        {
          id: 3,
          image: 'https://theme.hstatic.net/1000341902/1001140246/14/policies_icon_3_thumb.png?v=755',
          title: 'Đảm bảo chất lượng',
          description: 'Hỗ trợ đổi hàng trong vòng 7 ngày'
        },
        {
          id: 4,
          image: 'https://theme.hstatic.net/1000341902/1001140246/14/policies_icon_4_thumb.png?v=755',
          title: 'Hotline: 0339245240',
          description: 'Dịch vụ hỗ trợ bạn 24/7'
        }
      ]
    }
  },
}
</script>

<style scoped>
.description{
  display: flex;
  justify-content: space-evenly
}
.home-description{
  width: 100%;
}
</style>