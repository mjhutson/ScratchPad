def run_quick_sort(array):
    sorted_array = sort(array, 0, len(array) - 1)
    for i in range(0, len(sorted_array)):
        print("{0}, ".format(sorted_array[i]), end = " ")


def sort(array, start, end):
    if (start < end):
        partition = split(array, start, end)
        sort(array, start, partition - 1)   # From start to index up to partition
        sort(array, partition + 1, end)     # From index after partition to the end of the array
    return array


def split(array, start, end):
    pivot = array[end]
    i = start - 1
    for j in range(start, end):
        if array[j] <= pivot:
            i = i + 1
            array = swap(array, i, j)       # (array[i], array[j]) = (array[j], array[i])
    array = swap(array, i + 1, end)         # (array[i + 1], array[end]) = (array[end], array[i + 1])
    return i + 1


def swap(array, index_1, index_2):
    temp = array[index_1]
    array[index_1] = array[index_2]
    array[index_2] = temp
    return array


test_array = [1,8,3,6,7,4,3,0]              # Run the sort
run_quick_sort(test_array)
