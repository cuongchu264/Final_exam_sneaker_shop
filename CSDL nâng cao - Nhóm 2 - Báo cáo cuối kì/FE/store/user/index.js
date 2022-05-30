// state
const state =  () => ({
    token: '',
    username: '',
    branch: ''
})
// mutations
const mutations = {
    SET_TOKEN (state, token){
        state.token = token
    },
    REMOVE_TOKEN(state)
    {
        state.token = ''
    },
    SET_NAME(state, username){
        state.username = username
    },
    REMOVE_NAME(state)
    {
        state.username = ''
    },
    SET_BRANCH(state, branch){
        state.branch = branch
    },
    REMOVE_BRANCH(state)
    {
        state.branch = ''
    }
}
// getters
const getters = {
    getToken(state) {
       return state.token;
    },
    isAuthen(state){
        return state.token !== '' 
    },
    getName(state) {
        return state.username;
    },
    getBranch(state) {
        return state.branch;
    },
}
// actions
const actions = {
    setToken({commit},token){
        commit('SET_TOKEN',token)
    },
    logout({commit}){
        commit('REMOVE_TOKEN')
        commit('REMOVE_NAME')
        commit('REMOVE_BRANCH')
    },
    setName({commit},username) {
        commit('SET_NAME',username)
    },         
    setBranch({commit},branch) {
        commit('SET_BRANCH',branch)
    },
    
}

export default{
    namespace: true,
    state,
    actions,
    getters,
    mutations
}