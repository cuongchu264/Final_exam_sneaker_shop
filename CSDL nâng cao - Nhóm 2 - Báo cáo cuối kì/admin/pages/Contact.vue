<template>
    <main>
        <div>
            <h3 class="text-center mt-4">" KHÁCH HÀNG HỖ TRỢ </h3>
                    <div style="text-align:center;">
                        <input  v-model="search" size="md" class="mr-md-2 text-center mt-3 mb-3" type="text" placeholder="Search">
                    </div>
                    <div class="container-fluid bg-white">
                        <table class="table mt-4">
                            <thead>
                                <tr>
                                <th scope="col" >ID <svg data-v-41be6633="" viewBox="0 0 16 16" width="1em" height="1em" focusable="false" role="img" aria-label="arrow down up" xmlns="http://www.w3.org/2000/svg" fill="currentColor" class="bi-arrow-down-up mx-auto b-icon bi"><g data-v-41be6633=""><path fill-rule="evenodd" d="M11.5 15a.5.5 0 0 0 .5-.5V2.707l3.146 3.147a.5.5 0 0 0 .708-.708l-4-4a.5.5 0 0 0-.708 0l-4 4a.5.5 0 1 0 .708.708L11 2.707V14.5a.5.5 0 0 0 .5.5zm-7-14a.5.5 0 0 1 .5.5v11.793l3.146-3.147a.5.5 0 0 1 .708.708l-4 4a.5.5 0 0 1-.708 0l-4-4a.5.5 0 0 1 .708-.708L4 13.293V1.5a.5.5 0 0 1 .5-.5z"></path></g></svg></th>
                                <th scope="col" >Tên KH <svg data-v-41be6633="" viewBox="0 0 16 16" width="1em" height="1em" focusable="false" role="img" aria-label="arrow down up" xmlns="http://www.w3.org/2000/svg" fill="currentColor" class="bi-arrow-down-up mx-auto b-icon bi"><g data-v-41be6633=""><path fill-rule="evenodd" d="M11.5 15a.5.5 0 0 0 .5-.5V2.707l3.146 3.147a.5.5 0 0 0 .708-.708l-4-4a.5.5 0 0 0-.708 0l-4 4a.5.5 0 1 0 .708.708L11 2.707V14.5a.5.5 0 0 0 .5.5zm-7-14a.5.5 0 0 1 .5.5v11.793l3.146-3.147a.5.5 0 0 1 .708.708l-4 4a.5.5 0 0 1-.708 0l-4-4a.5.5 0 0 1 .708-.708L4 13.293V1.5a.5.5 0 0 1 .5-.5z"></path></g></svg></th>
                                <th scope="col">Email</th>
                                <th scope="col">Số điện thoại</th>
                                <th scope="col">Mô tả</th>
                                <th scope="col">Ngày</th>
                                <th scope="col">Chi nhánh</th>
                                <th scope="col">Xủ lý</th>
                                </tr>
                            </thead>
                            <tbody >
                                <tr v-for="(customer,index) in filteredCustomer" :key="index">
                                    <th scope="row">{{ index+1 }}</th>
                                    <td>{{ customer.customerSPName }}</td>
                                    <td>{{ customer.customerSPEmail }}</td>
                                    <td>{{ customer.customerSPPhone }}</td>
                                    <td>{{ customer.customerSPDescriptions }}</td>
                                    <td>{{ customer.dayCreated }}</td>
                                    <td v-if="customer.branchId == 1" td>Đà Nẵng</td>
                                    <td  v-else >Sài Gòn</td>
                                    <td><a type="button" class="btn btn-success" @click="UpdateCustomer()" >Edit</a></td>
                                     <td><button class="btn btn-danger" @click="DeleteCustomer(customer.customerSPId)" >Delete</button></td>
                                </tr>
                            </tbody>
                        </table>
                        <p class="text-center">
                            <button class="btn btn-success" @click="prevPage" :hidden="cantGoBack">Previous</button> 
                            Trang {{currentPage}}
                            <button class="btn btn-success" @click="nextPage" :hidden="this.currentPage > cantGoNext">Next</button>
                        </p>
                    </div>
        </div>
    </main>
</template>
<script>
import catalogApi from '@/api/catalogApi'
export default {
    middleware: ['isAuthorize'],
    data(){
        return{
            loadListCustomertSP:[],
            search:'',
            pageSize:10, 
            currentPage:1
        }
    },
    async created(){
        this.loadListCustomert()
    },

    computed:{

        cantGoBack() {
            return this.currentPage === 1;
        },
        cantGoNext() {
            var totalPages = (Math.floor(this.filteredCustomer.length / this.pageSize)) + 1;
            return totalPages;
        },


        filteredCustomer(){
            return this.loadListCustomertSP.filter((usercustomer) =>{
                return usercustomer.customerSPName.toLowerCase().match(this.search.toLowerCase())
            });
        },

    },

    methods:{

        async loadListCustomert(){
                try{
                const { data } = await catalogApi.getCustomertSP(this.$axios)
                console.log(data)
                this.loadListCustomertSP = data
                }catch(err){
                console.log(err)
                }
        },


            nextPage:function() {
            this.currentPage++;
            this.loadListCustomert();
            },
            prevPage:function() {
            if(this.currentPage > 1) this.currentPage--;
            this.loadListCustomert();
        },

                DeleteCustomer(id) {
            const choice = confirm("Bạn có muốn xóa không?");
                if (choice === true) {
                    this.$axios.delete('/api/CustomerSPs/'+ id ).then(() =>{
                        this.loadListCustomert()
                    })
                }
                else{
                    this.$router.push("/Contact")
                }

        },
                UpdateCustomer() {
                alert("chức năng đang xây dựng")

        },
    },  
}
</script>