import { Mutex } from 'async-mutex'
import moment from 'moment'
import Cookies from 'universal-cookie'
import { CartApi, ShoppingCartDto } from '../api'

const mutex = new Mutex()

export async function getOrCreateCart(currencyCode: string): Promise<ShoppingCartDto> {
    const api = new CartApi()
    const cookies = new Cookies()

    const release = await mutex.acquire()
    let cartId = cookies.get("cartId")
    if (!cartId || cartId === 'undefined') {
        let response = await api.apiCartCreateCartPost({});
        cartId = response
        cookies.set("cartId", cartId, { expires: moment().add(7, 'days').toDate() })
    }
    release()

    return api.apiCartGetCartByIdIdGet({ id: cartId, currencyCode: currencyCode })
}