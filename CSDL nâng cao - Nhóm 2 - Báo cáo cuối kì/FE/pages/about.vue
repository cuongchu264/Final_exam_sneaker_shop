<template>
<main>
    <h1 class="text-center mt-2">" GIỚI THIỆU "</h1>
    <section  style="background-image: url('https://i.pinimg.com/736x/b9/f9/cb/b9f9cbf47532518f6f1c2b7191e56da1.jpg');">
        <div class="container mt-3">
            <div class="bg-white">
                <b-media>
                    <template #aside>
                        <b-img src="@/img/logo.png" height="75" width="78" alt="placeholder"></b-img>
                    </template>

                    <h5 class="mt-0">Sneaker Shop</h5>
                    <p>
                        Xin chào quý khách! – Chào mừng quý khách đến với Website bán hàng của <strong> Sneaker Shop</strong>. 
                    </p>

                    <b-media class="mt-3" v-for="(founder,index) in listFounder" :key="index">
                        <template #aside>
                        <b-img :src="founder.founderImg" width="64" rounded="circle"></b-img>
                        </template>

                        <h5 class="mt-0">{{ founder.founderName }}</h5>
                        <p class="mb-0">
                            {{ founder.founderComment }}
                        </p>
                    </b-media>
                </b-media>
            </div>
            <style>
                .about:{
                    background-color: red ; !important
                }
            </style>
        </div>
    </section>
</main>
</template>
<script>
import catalogApi from '@/api/catalogApi'
export default {
    data(){
        return{
            listFounder: [],
        }
    },
    async created(){
    await this.getFounders()
    },
    methods:{
        async getFounders(){
            try{
                const { data } = await catalogApi.getFounder(this.$axios)
                console.log(data)
                this.listFounder = data
            }catch(err){
                console.log(err)
            }
        },
    }
}
</script>
